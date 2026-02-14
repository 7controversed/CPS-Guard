using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Microsoft.Win32;
using Guna.UI2.WinForms;

namespace CPS_Guard
{

    public partial class Form1 : Form
    {
        #region Configuration & Principaux trucs

        // Paramètres main
        public static bool IsGuardActive = false; 
        public static int CurrentLimitValue = 12;           
        public static int CurrentDebounceValue = 30;       
        public static bool IsAppDisabledWhenCursorInside = false; 

        // Modes de Fonctionnement
        // 0 = Hard Cut (Coupe stricte dès que la limite est atteinte)
        // 1 = Soft Cut (Autorise des pics légers, bloque selon une probabilité)
        // 2 = Pulse Cut (La limite oscille comme une respiration, on humanise quoi)
        public static int DetectionMode = 0;
        public static int ToleranceBurst = 2;               

        // Variables du mode Pulse
        private double _pulsePhase = 0;
        private double _currentPulseLimit = 0;              

        #endregion

        #region Aspects techniques
        // Infos processus et divers
        private int _myProcessId;                          
        private bool _isCursorOverApp = false;             
        private Random _rnd = new Random();                 

        // Réseau et chrono
        private static readonly HttpClient _httpClient = new HttpClient();
        private static readonly Stopwatch _globalWatch = Stopwatch.StartNew();

        // Visuel
        private const int POS_Y = 365;
        private const int TARGET_OPEN_X = 245;
        private const int TARGET_CLOSED_X = 410;

        private bool _isNotifOpen = false;
        private bool _isInitializationComplete = false;

        // Statistiques et visuels
        private int _targetCPSValueLeft = 0;
        private int _targetCPSValueRight = 0;
        private double _currentDisplayedLeft = 0;
        private double _currentDisplayedRight = 0;         

        public static int SessionInternalPeakCPS = 0;       
        private DateTime _lastAlertTime = DateTime.MinValue;
        private DateTime _lastHeartbeatTime = DateTime.Now;

        // Système de bind
        private bool _isBinding = false; 
        private int _bindingCountdown = 5;
        private Timer _timerBinding;
        private DateTime _lastKeybindToggle = DateTime.MinValue;
        private Keys _currentKeybind = Keys.None;

        // Variable pour le clavier
        private bool _isKeyAlreadyDown = false;

        // Variables pour éviter de spammer le fichier de logs avec les mêmes infos
        private int _lastLogLimit = 0;
        private int _lastLogCeiling = 0;
        private int _lastLogDebounce = 0;
        private int _lastLogTolerance = 0;

        #endregion

        #region Accès aux sources

        // Liens pour vérifier les mises à jour et les réseaux sociaux
        private const string REMOTE_VERSION_URL = "https://raw.githubusercontent.com/7controversed/CPS-Guard/refs/heads/settings/version";
        private const string DOWNLOAD_URL = "https://github.com/7controversed/CPS-Guard/releases";
        private const string URL_SRC_TIKTOK = "https://raw.githubusercontent.com/7controversed/CPS-Guard/refs/heads/settings/tiktoklnk";
        private const string URL_SRC_YOUTUBE = "https://raw.githubusercontent.com/7controversed/CPS-Guard/refs/heads/settings/youtubelnk";
        private const string URL_SRC_DISCORD = "https://raw.githubusercontent.com/7controversed/CPS-Guard/refs/heads/settings/discordlnk";

        private const string CURRENT_VERSION = "1.2";

        private string _linkTikTok = "";
        private string _linkYoutube = "";
        private string _linkDiscord = "";

        #endregion

        #region Hooks & et définitions

        // Mouse hook :
        // C'est la méthode qui bloque "physiquement" un clic avant qu'il n'atteigne le jeu
        // On garde celui-là car il est moins suspect que le hook clavier pour les antivirus
        private static IntPtr _mouseHookID = IntPtr.Zero;
        private LowLevelMouseProc _mouseProc;

        // NOTE : Le hook clavier a été supprimé pour réduire les faux positifs antivirus
        // J'utilise maintenant le Polling (GetAsyncKeyState) pour le clavier

        // Timestamps pour le Debounce (Anti-Double Clicks)
        private long _lastLeftClickTick = 0;
        private long _lastRightClickTick = 0;

        // Historique des clicks
        // _clickHistory : Clicks qui ont été validés
        // _rawClickHistory : Tous les clics physiques (bloqués + validés)
        private List<long> _clickHistoryLeft = new List<long>(100);
        private List<long> _rawClickHistoryLeft = new List<long>(100);
        private List<long> _clickHistoryRight = new List<long>(100);
        private List<long> _rawClickHistoryRight = new List<long>(100);

        private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

        // WinAPI etc

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, MulticastDelegate lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint(Point Point);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        [DllImport("shell32.dll")]
        private static extern int SHQueryUserNotificationState(out int pquns);

        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

        // Constantes Windows
        private const int WH_MOUSE_LL = 14;
        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_RBUTTONDOWN = 0x0204;
        private const int WM_MBUTTONDOWN = 0x0207;
        private const int WM_MOUSEMOVE = 0x0200;

        [StructLayout(LayoutKind.Sequential)]
        private struct MSLLHOOKSTRUCT { public Point pt; public uint mouseData; public uint flags; public uint time; public IntPtr dwExtraInfo; }

        #endregion

        public Form1()
        {
            InitializeComponent();

            // Préparation du hook souris
            _mouseProc = HookCallback;

            _myProcessId = Process.GetCurrentProcess().Id;

            // Timer pour le compte à rebours quand on définit une touche
            _timerBinding = new Timer();
            _timerBinding.Interval = 1000;
            _timerBinding.Tick += TimerBinding_Tick;

            _httpClient.Timeout = TimeSpan.FromSeconds(5);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true; // Évite quelques bugs de visu
            this.KeyPreview = true;     // Permet à la Form de capter les touches avant les boutons (pour le binding)

            LoadSettings();

            // Initialisation interface
            UpdateGuardVisuals(IsGuardActive);
            UpdateCeilingLabel(CurrentLimitValue);
            UpdateDebounceLabel(CurrentDebounceValue);

            if (ToleranceBurst < 1) ToleranceBurst = 1;
            if (ToleranceBurst > tbTolerance.Maximum) ToleranceBurst = tbTolerance.Maximum;

            tbTolerance.Value = ToleranceBurst;
            UpdateToleranceText();

            // États initiaux UI
            IsAppDisabledWhenCursorInside = cbDisableApp.Checked;
            tbLimit.Enabled = cbAlert.Checked;
            lbCPSLimit.Text = $"{tbLimit.Value} CPS";
            UpdateAlertWarning();

            lbLiveCPS.Text = "0 | 0";
            gaugeLeft.Value = 0;
            gaugeRight.Value = 0;

            UpdateKeybindButtonText();

            // Initialisation des trackers de logs
            _lastLogCeiling = CurrentLimitValue;
            _lastLogDebounce = CurrentDebounceValue;
            _lastLogLimit = tbLimit.Value;
            _lastLogTolerance = ToleranceBurst;

            // Configuration System Tray (Icône barre des tâches)
            ContextMenuStrip ctxMenu = new ContextMenuStrip();
            ctxMenu.Items.Add("Show", null, (s, ev) => RestoreFromTray());
            ctxMenu.Items.Add("Exit", null, (s, ev) => ForceExitApp());
            TrayIcon.ContextMenuStrip = ctxMenu;
            TrayIcon.Text = "CPS Guard";
            TrayIcon.Visible = true;

            // Logique de démarrage caché - si activé
            if (cbStartHidden.Checked)
            {
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                BeginInvoke(new MethodInvoker(() => this.Hide()));
            }

            // Installation du Hook Souris (Guard)
            _mouseHookID = SetHook(_mouseProc, WH_MOUSE_LL);

            // Démarrage du Polling Clavier (Le guetteur du tieks)
            Timer timerKeyCheck = new Timer();
            timerKeyCheck.Interval = 50;
            timerKeyCheck.Tick += TimerKeyCheck_Tick;
            timerKeyCheck.Start();

            // Démarrage des Timers
            TimerRealCPS.Interval = 25; TimerRealCPS.Start();         // Global pour les CPS
            TimerSmoothUI.Interval = 16; TimerSmoothUI.Start();       // Animation
            TimerAntiFreeze.Interval = 1000; TimerAntiFreeze.Start(); // Antifreeze

            // Timer pour vérifier si la souris est SUR l'application
            Timer timerContextCheck = new Timer();
            timerContextCheck.Interval = 500;
            timerContextCheck.Tick += TimerContextCheck_Tick;
            timerContextCheck.Start();

            AddLog($"CPS Guard has been launched.");
            AddLog($"Max CPS Ceiling: set to {CurrentLimitValue} CPS.");
            AddLog($"Debounce Time: set to {CurrentDebounceValue} ms.");
            AddLog($"Ceiling behavior: set to {GetModeName()}.");

            _isInitializationComplete = true;

            // Vérification MAJ
            await CheckForUpdates();

            this.Opacity = 1;
            SaveAllSettings();
        }

        #region Logique & Divers

        private string GetModeName()
        {
            if (DetectionMode == 0) return "Hard Cut";
            if (DetectionMode == 1) return "Soft Cut";
            return "Pulse Cut";
        }

        private void UpdateToleranceText()
        {
            string symbol = (DetectionMode == 2) ? "±" : "+";
            lbToleranceValue.Text = $"{symbol}{tbTolerance.Value} cps";
        }

        // Génère un nombre aléatoire selon une distribution gaussienne.
        // Sert à simuler un délai "humain" imparfait pour le Debounce, pour éviter un ban par erreur
        private double GetGaussian(double mean, double stdDev)
        {
            double u1 = 1.0 - _rnd.NextDouble();
            double u2 = 1.0 - _rnd.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
            return mean + (stdDev * randStdNormal);
        }

        // Logique du clavier polling
        private void TimerKeyCheck_Tick(object sender, EventArgs e)
        {

            if (_isBinding) return;

            if (!cbEKeybind.Checked || _currentKeybind == Keys.None) return;

            int vKey = (int)_currentKeybind;

            short keyState = GetAsyncKeyState(vKey);
            bool isDown = (keyState & 0x8000) != 0;

            if (isDown)
            {
                if (!_isKeyAlreadyDown)
                {
                    _isKeyAlreadyDown = true;

                    if ((DateTime.Now - _lastKeybindToggle).TotalMilliseconds >= 1000)
                    {
                        _lastKeybindToggle = DateTime.Now;
                        btnGuard_Click(null, null);
                    }
                }
            }
            else
            {
                _isKeyAlreadyDown = false; 
            }
        }

        #endregion

        #region Hook (souris uniquement)

        // Le code global pour la souris (hook etc)

        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            // Question de sécu : Si c'est juste un mouvement de souris, ça passe
            if (nCode >= 0 && wParam == (IntPtr)WM_MOUSEMOVE) return CallNextHookEx(_mouseHookID, nCode, wParam, lParam);

            bool isLeftClick = (wParam == (IntPtr)WM_LBUTTONDOWN);
            bool isRightClick = (wParam == (IntPtr)WM_RBUTTONDOWN);
            bool isMiddleClick = (wParam == (IntPtr)WM_MBUTTONDOWN);

            // Logique binding
            if (_isBinding)
            {
                if (isMiddleClick)
                {
                    SaveNewKeybind(Keys.MButton);
                    StopBindingMode();
                    return (IntPtr)1;
                }
                if (isLeftClick || isRightClick) return CallNextHookEx(_mouseHookID, nCode, wParam, lParam);
            }

            if (cbEKeybind.Checked && !IsGuardActive && _currentKeybind == Keys.MButton && isMiddleClick)
            {
                if ((DateTime.Now - _lastKeybindToggle).TotalMilliseconds >= 1000)
                {
                    _lastKeybindToggle = DateTime.Now;
                    this.BeginInvoke(new MethodInvoker(() => { btnGuard_Click(null, null); }));
                }
            }

            // Filtrage et compagnie
            if (nCode >= 0 && (isLeftClick || isRightClick))
            {
                MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));

                if ((hookStruct.flags & 0x01) == 0x01) return CallNextHookEx(_mouseHookID, nCode, wParam, lParam);

                if (IsAppDisabledWhenCursorInside && _isCursorOverApp) return CallNextHookEx(_mouseHookID, nCode, wParam, lParam);

                if (isLeftClick && !cbLeft.Checked) return CallNextHookEx(_mouseHookID, nCode, wParam, lParam);

                if (isRightClick && !cbRight.Checked) return CallNextHookEx(_mouseHookID, nCode, wParam, lParam);

                long nowTicks = _globalWatch.ElapsedMilliseconds;
                List<long> targetClickHistory = isLeftClick ? _clickHistoryLeft : _clickHistoryRight;
                List<long> targetRawHistory = isLeftClick ? _rawClickHistoryLeft : _rawClickHistoryRight;

                lock (targetRawHistory) { targetRawHistory.Add(nowTicks); }

                if (!IsGuardActive)
                {
                    lock (targetClickHistory) { targetClickHistory.Add(nowTicks); }
                    return CallNextHookEx(_mouseHookID, nCode, wParam, lParam);
                }

                // Bloque les clics qui arrivent vite après le précédent
                int effectiveDebounce = (int)GetGaussian(CurrentDebounceValue, 3.0);
                if (effectiveDebounce < 5) effectiveDebounce = 5;

                long lastTime = isLeftClick ? _lastLeftClickTick : _lastRightClickTick;
                if (nowTicks - lastTime < effectiveDebounce) return (IntPtr)1; // BLOQUÉ ! (Trop rapide)

                // Limite CPS
                lock (targetClickHistory)
                {
                    int currentCount = targetClickHistory.Count;

                    if (DetectionMode == 0) // HARD CUT (Coupe stricte)
                    {
                        if (currentCount >= CurrentLimitValue) return (IntPtr)1;
                    }
                    else // SOFT et PULSE
                    {
                        // En Pulse, la limite bouge, en Soft, elle est fixe
                        double limitReference = (DetectionMode == 2) ? _currentPulseLimit : (double)CurrentLimitValue;
                        double excess = (double)currentCount - limitReference;

                        if (excess >= 0)
                        {
                            // Si on dépasse trop la tolérance = Blocage strict
                            if (excess > ToleranceBurst) return (IntPtr)1;

                            // Sinon = Blocage probabiliste (Plus il dépasse, plus il a de chance d'être bloqué)
                            double ratio = (ToleranceBurst > 0) ? excess / (double)(ToleranceBurst + 1) : 1.0;
                            int blockChance = (int)((ratio * ratio) * 100) + 5;

                            if (_rnd.Next(0, 100) < blockChance) return (IntPtr)1;
                        }
                    }

                    // Click validé
                    targetClickHistory.Add(nowTicks);
                }

                // Maj du timestamp pour le prochain check debounce
                if (isLeftClick) _lastLeftClickTick = nowTicks;
                else _lastRightClickTick = nowTicks;
            }

            return CallNextHookEx(_mouseHookID, nCode, wParam, lParam);
        }

        #endregion

        #region Logique des timers

        // Timer rapide (25ms). Le cerveau qui recalcule les CPS et gère le mode Pulse

        private void TimerRealCPS_Tick(object sender, EventArgs e)
        {
            long now = _globalWatch.ElapsedMilliseconds;
            long cutoff = now - 1000; 

            // Logique PULSE
            if (DetectionMode == 2)
            {
                _pulsePhase += 0.05;
                if (_pulsePhase > Math.PI * 2) _pulsePhase -= Math.PI * 2;

                // Variations
                double variation = Math.Sin(_pulsePhase) * 1.5;
                _currentPulseLimit = (double)CurrentLimitValue + variation;
                if (_currentPulseLimit < 4) _currentPulseLimit = 4;
            }

            // Nettoyage des vieux clics de l'historique et UI
            int acceptedCPSLeft = 0; int totalRawCPSLeft = 0;
            int acceptedCPSRight = 0; int totalRawCPSRight = 0;

            lock (_clickHistoryLeft) { _clickHistoryLeft.RemoveAll(t => t < cutoff); acceptedCPSLeft = _clickHistoryLeft.Count; }
            lock (_rawClickHistoryLeft) { _rawClickHistoryLeft.RemoveAll(t => t < cutoff); totalRawCPSLeft = _rawClickHistoryLeft.Count; }
            lock (_clickHistoryRight) { _clickHistoryRight.RemoveAll(t => t < cutoff); acceptedCPSRight = _clickHistoryRight.Count; }
            lock (_rawClickHistoryRight) { _rawClickHistoryRight.RemoveAll(t => t < cutoff); totalRawCPSRight = _rawClickHistoryRight.Count; }

            if (IsGuardActive && DetectionMode > 0 && (acceptedCPSLeft > CurrentLimitValue || acceptedCPSRight > CurrentLimitValue))
                lbLiveCPS.ForeColor = Color.FromArgb(255, 80, 80);
            else
                lbLiveCPS.ForeColor = Color.White;

            // Mise à jour du record de session : inutilisé pour l'instant
            int currentMax = Math.Max(acceptedCPSLeft, acceptedCPSRight);
            if (currentMax > SessionInternalPeakCPS) SessionInternalPeakCPS = currentMax;

            // Logique d'alerte Windows
            if (cbAlert.Checked && (acceptedCPSLeft > tbLimit.Value || acceptedCPSRight > tbLimit.Value))
            {
                if ((DateTime.Now - _lastAlertTime).TotalSeconds > 5)
                {
                    string msg = acceptedCPSLeft > tbLimit.Value ? $"Left: {acceptedCPSLeft}" : $"Right: {acceptedCPSRight}";
                    TrayIcon.ShowBalloonTip(2000, "CPS Alert", $"Limit Exceeded! {msg}", ToolTipIcon.Warning);
                    _lastAlertTime = DateTime.Now;
                    AddLog($"Alert: High CPS detected ({msg})");
                }
            }

            // Affichage des CPS supprimés
            int removedLeft = totalRawCPSLeft - acceptedCPSLeft;
            lbRemovedCpsLeft.Text = removedLeft > 0 ? $"-{removedLeft} cps (L)" : "";
            lbRemovedCpsLeft.Visible = removedLeft > 0;

            int removedRight = totalRawCPSRight - acceptedCPSRight;
            lbRemovedCpsRight.Text = removedRight > 0 ? $"-{removedRight} cps (R)" : "";
            lbRemovedCpsRight.Visible = removedRight > 0;

            UpdateLiveCPSTarget(acceptedCPSLeft, acceptedCPSRight);
        }

        #endregion

        #region Evenements et UI


        // Gestion des touches Clavier pour le binding

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (_isBinding)
            {
                e.SuppressKeyPress = true; 
                if (e.KeyCode == Keys.Escape)
                {
                    ResetKeybind();
                    StopBindingMode();
                }
                else
                {
                    // Touches bypass pour éviter certaines touches problématiques
                    if (e.KeyCode != Keys.LWin && e.KeyCode != Keys.RWin)
                    {
                        SaveNewKeybind(e.KeyCode);
                        StopBindingMode();
                    }
                }
            }
        }

        // Gestionnaires des modes
        private void rbModeCutoff_CheckedChanged(object sender, EventArgs e)
        {
            if (rbModeCutoff.Checked)
            {
                DetectionMode = 0;
                tbTolerance.Enabled = false;
                UpdateToleranceText();
                if (_isInitializationComplete) AddLog($"Ceiling behavior: set to {GetModeName()}.");
            }
        }

        private void rbModeTolerant_CheckedChanged(object sender, EventArgs e)
        {
            if (rbModeTolerant.Checked)
            {
                DetectionMode = 1;
                tbTolerance.Enabled = true;
                UpdateToleranceText();
                if (_isInitializationComplete) AddLog($"Ceiling behavior: set to {GetModeName()}.");
            }
        }

        private void rbModePulse_CheckedChanged(object sender, EventArgs e)
        {
            if (rbModePulse.Checked)
            {
                DetectionMode = 2;
                tbTolerance.Enabled = true;
                _pulsePhase = 0;
                UpdateToleranceText();
                if (_isInitializationComplete) AddLog($"Ceiling behavior: set to {GetModeName()}.");
            }
        }

        // Gestion des Paramètres (Sauvegarde et chargement)
        private void LoadSettings()
        {
            AppConfig config = ConfigManager.Load();
            CurrentLimitValue = config.CeilingCPS;
            CurrentDebounceValue = config.DebounceMS;
            IsGuardActive = config.GuardState;

            cbRunStartup.Checked = config.RunStartup;
            cbStartHidden.Checked = config.StartHidden;
            cbTray.Checked = config.TrayMinimize;
            cbDisableApp.Checked = config.DisableApp;
            cbAlert.Checked = config.AlertActive;
            tbLimit.Value = config.AlertLimit;
            cbCheckUpdates.Checked = config.CheckUpdates;
            cbLeft.Checked = config.LeftCount;
            cbRight.Checked = config.RightCount;
            cbEKeybind.Checked = config.EnabledKeybind;
            _currentKeybind = (Keys)config.KeybindValue;
            cbSaveLogs.Checked = config.SavingLogs;

            tbCeiling.Value = CurrentLimitValue;
            tbDebouncetime.Value = CurrentDebounceValue;
            ToleranceBurst = config.ToleranceLevel;

            DetectionMode = config.DetectionMode;
            if (DetectionMode == 0) rbModeCutoff.Checked = true;
            else if (DetectionMode == 1) rbModeTolerant.Checked = true;
            else if (DetectionMode == 2) rbModePulse.Checked = true;
            UpdateToleranceText();
        }

        private void SaveAllSettings()
        {
            AppConfig config = new AppConfig();
            config.CeilingCPS = tbCeiling.Value;
            config.DebounceMS = tbDebouncetime.Value;
            config.RunStartup = cbRunStartup.Checked;
            config.StartHidden = cbStartHidden.Checked;
            config.TrayMinimize = cbTray.Checked;
            config.DisableApp = cbDisableApp.Checked;
            config.AlertActive = cbAlert.Checked;
            config.AlertLimit = tbLimit.Value;
            config.CheckUpdates = cbCheckUpdates.Checked;
            config.LeftCount = cbLeft.Checked;
            config.RightCount = cbRight.Checked;
            config.EnabledKeybind = cbEKeybind.Checked;
            config.KeybindValue = (int)_currentKeybind;
            config.SavingLogs = cbSaveLogs.Checked;
            config.GuardState = IsGuardActive;
            config.DetectionMode = DetectionMode;
            config.ToleranceLevel = ToleranceBurst;
            config.CeilMode = false;

            ConfigManager.Save(config);
        }

        // Système de Maj
        private async Task CheckForUpdates()
        {
            await Task.Delay(3000); 
            try
            {
                string rawVersion = await _httpClient.GetStringAsync(REMOTE_VERSION_URL);
                string latestVersion = rawVersion.Trim();
                Version currentVer = new Version(CURRENT_VERSION);
                Version remoteVer = new Version(latestVersion);

                var t1 = _httpClient.GetStringAsync(URL_SRC_TIKTOK);
                var t2 = _httpClient.GetStringAsync(URL_SRC_YOUTUBE);
                var t3 = _httpClient.GetStringAsync(URL_SRC_DISCORD);

                try { _linkTikTok = (await t1).Trim(); } catch { }
                try { _linkYoutube = (await t2).Trim(); } catch { }
                try { _linkDiscord = (await t3).Trim(); } catch { }

                if (remoteVer > currentVer && cbCheckUpdates.Checked)
                {
                    ShowNotification();
                    if (_isInitializationComplete) AddLog($"Update: New version available: {latestVersion}");
                }
                else
                {
                    pnlUpdate.Visible = false;
                }
            }
            catch
            {
                pnlUpdate.Visible = false;
            }
        }

        private void pnlUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(DOWNLOAD_URL);
                _isNotifOpen = false;
            }
            catch { }
        }

        // Animation UI etc

        private void TimerSmoothUI_Tick(object sender, EventArgs e)
        {
         
            const double SPEED_FACTOR = 0.45;
            double maxVisualCPS = (double)CurrentLimitValue;
            if (maxVisualCPS < 5) maxVisualCPS = 5;

            _currentDisplayedLeft = _currentDisplayedLeft + (_targetCPSValueLeft - _currentDisplayedLeft) * SPEED_FACTOR;
            int percentLeft = (int)((_currentDisplayedLeft / maxVisualCPS) * 100);
            gaugeLeft.Value = percentLeft > 100 ? 100 : (percentLeft < 0 ? 0 : percentLeft);

            _currentDisplayedRight = _currentDisplayedRight + (_targetCPSValueRight - _currentDisplayedRight) * SPEED_FACTOR;
            int percentRight = (int)((_currentDisplayedRight / maxVisualCPS) * 100);
            gaugeRight.Value = percentRight > 100 ? 100 : (percentRight < 0 ? 0 : percentRight);

            AnimNotification();
        }

        private void AnimNotification()
        {
            int currentX = pnlUpdate.Location.X;
            if (_isNotifOpen)
            {
      
                int targetX = TARGET_OPEN_X;
                if (Math.Abs(targetX - currentX) < 1)
                {
                    pnlUpdate.Location = new Point(targetX, POS_Y);
                    return;
                }
                int nextX = currentX + (int)((targetX - currentX) * 0.2);
                pnlUpdate.Location = new Point(nextX == currentX ? nextX - 1 : nextX, POS_Y);
            }
            else
            {
           
                int targetX = TARGET_CLOSED_X;
                int nextX = currentX + (3 + (int)((currentX - TARGET_OPEN_X) * 0.15));

                if (nextX >= targetX)
                {
                    pnlUpdate.Location = new Point(targetX, POS_Y);
                    pnlUpdate.Visible = false;
                }
                else
                {
                    pnlUpdate.Location = new Point(nextX, POS_Y);
                }
            }
        }



        // Fix de potentiels bug d'animation

        protected override void WndProc(ref Message m)
        {

            const int WM_ENTERSIZEMOVE = 0x0231;
            const int WM_EXITSIZEMOVE = 0x0232;
            if (m.Msg == WM_ENTERSIZEMOVE) TimerSmoothUI.Stop();
            else if (m.Msg == WM_EXITSIZEMOVE) TimerSmoothUI.Start();
            base.WndProc(ref m);
        }

        #endregion

        #region Divers codes UI

        // Fonction technique pour installer le Hook
        private IntPtr SetHook(MulticastDelegate proc, int hookType)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(hookType, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        // Vérification régulière si la souris est au-dessus de NOTRE fenêtre

        private void TimerContextCheck_Tick(object sender, EventArgs e)
        {
            if (!IsAppDisabledWhenCursorInside)
            {
                _isCursorOverApp = false;
                return;
            }

            try
            {
                // Récupère l'ID du processus qui est sous la souris
                GetWindowThreadProcessId(WindowFromPoint(Cursor.Position), out int procId);
                // Si l'ID correspond, alors la souris est sur l'app
                _isCursorOverApp = (procId == _myProcessId);
            }
            catch
            {
                _isCursorOverApp = false;
            }
        }

        // Met à jour les textes des compteurs CPS en direct
        private void UpdateLiveCPSTarget(int cpsLeft, int cpsRight)
        {
            lbLiveCPS.Text = $"{cpsLeft} | {cpsRight}";
            _targetCPSValueLeft = cpsLeft;
            _targetCPSValueRight = cpsRight;
        }

        // Gestion de la case à cocher "Click gauche"
        private void cbLeft_CheckedChanged_1(object sender, EventArgs e)
        {
            // Sécurité : Interdiction de désactiver gauche et droite en même temps
            if (!cbLeft.Checked && !cbRight.Checked)
            {
                cbLeft.Checked = true;
            }
            else if (_isInitializationComplete)
            {
                AddLog(cbLeft.Checked ? "Left click counting enabled." : "Left click counting disabled.");
            }
        }

        // Gestion de la case à cocher "Click droit"
        private void cbRight_CheckedChanged_1(object sender, EventArgs e)
        {
            // Sécurité : Interdiction de désactiver gauche et droite en même temps
            if (!cbRight.Checked && !cbLeft.Checked)
            {
                cbRight.Checked = true;
            }
            else if (_isInitializationComplete)
            {
                AddLog(cbRight.Checked ? "Right click counting enabled." : "Right click counting disabled.");
            }
        }

        // Le masterchef des boutons (activateur)
        private void btnGuard_Click(object sender, EventArgs e)
        {
            bool newState = !IsGuardActive; 
            UpdateGuardVisuals(newState);

            _lastLeftClickTick = _globalWatch.ElapsedMilliseconds;
            _lastRightClickTick = _globalWatch.ElapsedMilliseconds;

            if (_isInitializationComplete)
            {
                AddLog(newState ? "CPS Guard enabled." : "CPS Guard disabled.");
            }
        }

        // Change d'état et de couleur suite à l'activation/désactivation
        private void UpdateGuardVisuals(bool isActive)
        {
            IsGuardActive = isActive;
            btnGuard.Checked = isActive;
            if (isActive)
            {
                btnGuard.Text = "Guard - Enabled";
                btnGuard.Image = Properties.Resources.shield_check;
                btnGuard.FillColor = Color.FromArgb(67, 203, 78);
                btnGuard.FillColor2 = Color.FromArgb(44, 182, 86);
            }
            else
            {
                btnGuard.Text = "Guard - Disabled";
                btnGuard.Image = Properties.Resources.shield_xmark;
                btnGuard.FillColor = Color.DimGray;
                btnGuard.FillColor2 = Color.FromArgb(64, 64, 64);
            }
        }

        // Quand on bouge le potard "max cps ceiling"
        private void tbCeiling_Scroll(object sender, ScrollEventArgs e)
        {
            CurrentLimitValue = tbCeiling.Value;
            UpdateCeilingLabel(CurrentLimitValue);
        }

        // Quand on bouge le potard "debounce time"
        private void tbDebouncetime_Scroll(object sender, ScrollEventArgs e)
        {
            CurrentDebounceValue = tbDebouncetime.Value;
            UpdateDebounceLabel(CurrentDebounceValue);
        }

        // Log quand on relâche le slider "alert on high cps"
        private void tbLimit_MouseUp(object sender, MouseEventArgs e)
        {
            if (tbLimit.Value != _lastLogLimit)
            {
                AddLog($"Alert Limit set to {tbLimit.Value} CPS.");
                _lastLogLimit = tbLimit.Value;
            }
        }

        // Log quand on lâche le potard des cps
        private void tbCeiling_MouseUp(object sender, MouseEventArgs e)
        {
            if (tbCeiling.Value != _lastLogCeiling)
            {
                AddLog($"Max CPS Ceiling: set to {tbCeiling.Value} CPS.");
                _lastLogCeiling = tbCeiling.Value;
            }
        }

        // Log quand on relâche le potard du debounce time
        private void tbDebouncetime_MouseUp(object sender, MouseEventArgs e)
        {
            if (tbDebouncetime.Value != _lastLogDebounce)
            {
                AddLog($"Debounce Time: set to {tbDebouncetime.Value} ms.");
                _lastLogDebounce = tbDebouncetime.Value;
            }
        }

        // Mise à jour du petit texte à côté du potard CPS
        private void UpdateCeilingLabel(int val)
        {
            lbCPSceiling.Text = $"{val} cps";
        }

        // Mise à jour du petit texte à côté du potard Debounce
        private void UpdateDebounceLabel(int val)
        {
            lbDebounceMS.Text = $"{val} ms";
        }

        // Option "Désactiver quand le curseur est dans l'app"
        private void cbDisableApp_CheckedChanged(object sender, EventArgs e)
        {
            IsAppDisabledWhenCursorInside = cbDisableApp.Checked;
            if (_isInitializationComplete) AddLog($"Disable inside app changed to {cbDisableApp.Checked}");
        }

        // Option "Alertes sonores/visuelles"
        private void cbAlert_CheckedChanged(object sender, EventArgs e)
        {
            tbLimit.Enabled = cbAlert.Checked;
            UpdateAlertWarning(); // Vérifie si Windows autorise les notifs
            if (_isInitializationComplete) AddLog(cbAlert.Checked ? "High CPS Alert enabled." : "High CPS Alert disabled.");
        }

        private void tbLimit_Scroll(object sender, ScrollEventArgs e)
        {
            lbCPSLimit.Text = $"{tbLimit.Value} CPS";
        }

        // Click sur le bouton pour définir une touche (Keybind)
        private void btnKeybind_Click(object sender, EventArgs e)
        {
            if (_isBinding) StopBindingMode(); // Si on clique alors qu'on attend, on annule
            else StartBindingMode(); // Sinon on commence l'attente
        }

        // Activation/Désactivation globale de la fonctionnalité Keybind
        private void cbEKeybind_CheckedChanged(object sender, EventArgs e)
        {
            if (_isInitializationComplete) AddLog(cbEKeybind.Checked ? "Keybind Activation enabled." : "Keybind Activation disabled.");
        }

        // Lance le mode "Appuyez sur une touche..."
        private void StartBindingMode()
        {
            _isBinding = true;
            _bindingCountdown = 5;
            btnKeybind.Text = $"Press a key ({_bindingCountdown})...";
            btnKeybind.FillColor = Color.FromArgb(232, 68, 84); 
            btnKeybind.FillColor2 = Color.FromArgb(252, 68, 94);
            _timerBinding.Start();
        }

        // Arrête le mode "Appuyez sur une touche"
        private void StopBindingMode()
        {
            _isBinding = false;
            _timerBinding.Stop();
            btnKeybind.FillColor = Color.FromArgb(70, 70, 70); 
            btnKeybind.FillColor2 = Color.FromArgb(74, 74, 74);
            UpdateKeybindButtonText();
        }

        // Compte à rebours de 5 secondes pour choisir une touche
        private void TimerBinding_Tick(object sender, EventArgs e)
        {
            _bindingCountdown--;
            if (_bindingCountdown > 0)
            {
                btnKeybind.Text = $"Press a key ({_bindingCountdown})...";
            }
            else
            {
                StopBindingMode();
                AddLog("Keybind: Time out. No key set.");
            }
        }

        // Sauvegarde la nouvelle touche choisie
        private void SaveNewKeybind(Keys key)
        {
            _currentKeybind = key;
            SaveAllSettings();
            AddLog($"Keybind: New key set to [{key}]");
            _lastKeybindToggle = DateTime.Now;
        }

        // Efface la touche configurée (Touche Echap)
        private void ResetKeybind()
        {
            _currentKeybind = Keys.None;
            SaveAllSettings();
            AddLog("Keybind: Keybind removed (None).");
        }

        // Met à jour le texte du bouton avec le nom de la touche
        private void UpdateKeybindButtonText()
        {
            btnKeybind.Text = (_currentKeybind == Keys.None || (int)_currentKeybind == 0) ? "[None]" : $"[{_currentKeybind}]";
        }

        private void cbSaveLogs_CheckedChanged(object sender, EventArgs e)
        {
            if (_isInitializationComplete) AddLog(cbSaveLogs.Checked ? "Auto-save logs enabled." : "Auto-save logs disabled.");
        }

        // Affiche le panneau de mise à jour (l'animation)
        private void ShowNotification()
        {
            pnlUpdate.Location = new Point(TARGET_CLOSED_X, POS_Y);
            pnlUpdate.Visible = true;
            pnlUpdate.BringToFront();
            _isNotifOpen = true;
        }

        // Ajoute un message dans la console de logs
        private void AddLog(string message)
        {
            if (tbLogs.InvokeRequired)
            {
                tbLogs.Invoke(new Action(() => AppendLogSafe($"[{DateTime.Now:HH:mm:ss}] : {message}\r\n")));
            }
            else
            {
                AppendLogSafe($"[{DateTime.Now:HH:mm:ss}] : {message}\r\n");
            }
        }

        // Écrit physiquement dans la TextBox des logs
        private void AppendLogSafe(string line)
        {
            tbLogs.AppendText(line);
            tbLogs.SelectionStart = tbLogs.Text.Length;
            tbLogs.ScrollToCaret();
        }

        // Quand CPS Guard se ferme

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Si l'utilisateur clique sur la croix rouge ET que l'option Tray est cochée
            if (e.CloseReason == CloseReason.UserClosing && cbTray.Checked)
            {
                e.Cancel = true; // Annule la fermeture
                this.Hide();     // Cache la fenêtre
                this.ShowInTaskbar = false;
                TrayIcon.ShowBalloonTip(1000, "CPS Guard", "Minimized to tray.", ToolTipIcon.Info);
                AddLog($"CPS Guard has been Minimized to tray.");
                return;
            }

            // Sinon, il ferme vraiment
            AddLog($"CPS Guard has been closed.");
            SaveAllSettings();

            // Sauvegarde des logs dans un fichier texte si accepté
            try
            {
                if (cbSaveLogs.Checked && !string.IsNullOrWhiteSpace(tbLogs.Text))
                {
                    string logsFolder = Path.Combine(ConfigManager.GetBaseFolder(), "logs");
                    if (!Directory.Exists(logsFolder)) Directory.CreateDirectory(logsFolder);
                    File.WriteAllText(Path.Combine(logsFolder, $"log_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.log"), tbLogs.Text);
                }
            }
            catch { }

            // IMPORTANT : Suppression du Hook Souris pour ne pas faire bug
            if (_mouseHookID != IntPtr.Zero) UnhookWindowsHookEx(_mouseHookID);
        }

        // Restaure l'application depuis la barre des tâches
        private void RestoreFromTray()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        // Force la fermeture complète (clic droit sur l'icône Tray et Exit)
        private void ForceExitApp()
        {
            Form1_FormClosing(this, new FormClosingEventArgs(CloseReason.ApplicationExitCall, false));
            Application.Exit();
        }

        // Liens vers les réseaux sociaux
        private void btnDiscord_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_linkDiscord)) Process.Start(_linkDiscord);
        }

        private void btnYoutube_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_linkYoutube)) Process.Start(_linkYoutube);
        }

        private void btnTiktok_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_linkTikTok)) Process.Start(_linkTikTok);
        }

        private void lbCred_Click(object sender, EventArgs e) => Process.Start("https://github.com/7controversed/CPS-Guard.git");

        // Vérifie si on a le droit d'afficher des notifications Windows
        private void UpdateAlertWarning()
        {
            if (!cbAlert.Checked)
            {
                lbAlertWarning.Visible = false;
                return;
            }
            lbAlertWarning.Visible = !AreNotificationsEnabled();
        }

        // Vérifie dans le registre Windows si les notifications sont activées
        private bool AreNotificationsEnabled()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\PushNotifications"))
                {
                    if (key != null)
                    {
                        object valToast = key.GetValue("ToastEnabled");
                        if (valToast != null && (int)valToast == 0) return false;
                    }
                }
            }
            catch { }
            int state;
            SHQueryUserNotificationState(out state);
            return state == 5; 
        }

        // Timer juste pour garder l'app active
        private void TimerAntiFreeze_Tick(object sender, EventArgs e)
        {
            _lastHeartbeatTime = DateTime.Now;
        }

        // Double click sur l'icône près de l'heure
        private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e) => RestoreFromTray();

        // Gestion du démarrage avec Windows (Registre)
        private void cbRunStartup_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                using (RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    if (cbRunStartup.Checked)
                    {
                        // Ajoute l'app au démarrage
                        rk.SetValue("CPSGuard", Application.ExecutablePath);
                        if (_isInitializationComplete) AddLog($"Auto-start enabled.");
                    }
                    else
                    {
                        // Retire l'app du démarrage
                        rk.DeleteValue("CPSGuard", false);
                        if (_isInitializationComplete) AddLog($"Auto-start disabled.");
                    }
                }
            }
            catch
            {
                if (_isInitializationComplete) AddLog($"ERROR: Permission denied for startup.");
            }
        }

        // Log quand on change l'option "Démarrer caché"
        private void cbStartHidden_CheckedChanged(object sender, EventArgs e)
        {
            if (_isInitializationComplete) AddLog(cbStartHidden.Checked ? "CPS Guard will start hidden." : "CPS Guard won't start hidden.");
        }

        // Log quand on change l'option "Minimiser dans le Tray"
        private void cbTray_CheckedChanged(object sender, EventArgs e)
        {
            if (_isInitializationComplete) AddLog(cbTray.Checked ? "Tray minimize enabled." : "Tray minimize disabled.");
        }

        // Log quand on change l'option "Vérifier les mises à jour"
        private void cbCheckUpdates_CheckedChanged(object sender, EventArgs e)
        {
            if (_isInitializationComplete) AddLog(cbCheckUpdates.Checked ? "Updates enabled." : "Updates disabled.");
        }

        // Ouvre les dossier des logs (roaming, cps guard, logs)
        private void btnOpenLogs_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("explorer.exe", Path.Combine(ConfigManager.GetBaseFolder(), "logs"));
                AddLog($"Logs folder opened.");
            }
            catch
            {
                AddLog($"Could not open logs folder.");
            }
        }

        // Gestion du potard de tolérance
        private void tbTolerance_Scroll(object sender, ScrollEventArgs e)
        {
            ToleranceBurst = tbTolerance.Value;
            UpdateToleranceText();
        }

        // Log quand on relâche le potard de tolérance
        private void tbTolerance_MouseUp(object sender, MouseEventArgs e)
        {
            if (tbTolerance.Value != _lastLogTolerance)
            {
                AddLog($"Click cut tolerance: set to +{tbTolerance.Value}.");
                _lastLogTolerance = tbTolerance.Value;
            }
        }

        #endregion
    }

    #region Classes des config

    // Paramètres de sauvegardes (fichier dans roaming, cps guard, config)
    public class AppConfig
    {
        public int CeilingCPS { get; set; } = 20;
        public int DebounceMS { get; set; } = 10;
        public bool RunStartup { get; set; } = false;
        public bool StartHidden { get; set; } = false;
        public bool TrayMinimize { get; set; } = false;
        public bool DisableApp { get; set; } = false;
        public bool AlertActive { get; set; } = false;
        public int AlertLimit { get; set; } = 18;
        public bool CheckUpdates { get; set; } = true;
        public bool LeftCount { get; set; } = true;
        public bool RightCount { get; set; } = false;
        public bool EnabledKeybind { get; set; } = false;
        public int KeybindValue { get; set; } = 0;
        public bool SavingLogs { get; set; } = true;
        public bool GuardState { get; set; } = false;
        public int DetectionMode { get; set; } = 0;
        public int ToleranceLevel { get; set; } = 2;
        public bool CeilMode { get; set; } = false;
    }

    // Sauvegarde et chargement
    public static class ConfigManager
    {
        // Chemin vers le fichier
        private static string FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CPS Guard");
        private static string ConfigPath = Path.Combine(FolderPath, "config.xml");

        public static string GetBaseFolder() { return FolderPath; }

        // Sauvegarde les paramètres dans le fichier
        public static void Save(AppConfig config)
        {
            try
            {
                if (!Directory.Exists(FolderPath)) Directory.CreateDirectory(FolderPath);
                XmlSerializer serializer = new XmlSerializer(typeof(AppConfig));
                using (StreamWriter writer = new StreamWriter(ConfigPath)) { serializer.Serialize(writer, config); }
            }
            catch { }
        }

        // Charge les paramètres depuis le fichier (ou en crée un vide si inexistant)
        public static AppConfig Load()
        {
            if (!File.Exists(ConfigPath)) return new AppConfig();
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(AppConfig));
                using (StreamReader reader = new StreamReader(ConfigPath)) { return (AppConfig)serializer.Deserialize(reader); }
            }
            catch { return new AppConfig(); }
        }
    }

    #endregion
}