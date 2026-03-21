using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using Guna.UI2.WinForms;

namespace CPS_Guard
{
    public partial class Form1 : Form
    {
        #region 1. Configuration & Variables Globales

        public static bool IsGuardActive = false;
        public static int CurrentLimitValue = 12;
        public static int CurrentDebounceValue = 30;
        public static bool IsAppDisabledWhenCursorInside = false;
        public static ILanguage CurrentLang = new LangEN();
        public static int DetectionMode = 0;
        private bool _isInitializationComplete = false;
        private bool _isForceExiting = false;
        public static int SessionInternalPeakCPS = 0;
        private DateTime _lastAlertTime = DateTime.MinValue;
        private DateTime _lastHeartbeatTime = DateTime.Now;
        private int _lastLogLimit = 0;
        private int _lastLogCeiling = 0;
        private int _lastLogDebounce = 0;
        private string _lastAdminProcName = "";
        private int _targetCPSValueLeft = 0;
        private int _targetCPSValueRight = 0;
        private double _currentDisplayedLeft = 0;
        private double _currentDisplayedRight = 0;

        #endregion

        #region 2. Initialisation

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            this.KeyPreview = true;

            AppLogger.OnLogAdded += AppLogger_OnLogAdded;
            KeybindManager.Initialize();
            KeybindManager.OnBindingTick += (countdown) => { btnKeybind.Text = CurrentLang.PressKey(countdown); };
            KeybindManager.OnBindingStopped += () => {
                btnKeybind.FillColor = Color.FromArgb(70, 70, 70);
                btnKeybind.FillColor2 = Color.FromArgb(74, 74, 74);
                UpdateKeybindButtonText();
            };
            KeybindManager.OnTriggerGuard += () => { this.BeginInvoke(new MethodInvoker(() => { btnGuard_Click(null, null); })); };

            ProcessMonitor.Initialize();
            ProcessMonitor.OnAdminProcessDetected += (procName) => {
                this.BeginInvoke(new MethodInvoker(() => {
                    _lastAdminProcName = procName;
                    if (lbADMINORNOT != null)
                    {
                        lbADMINORNOT.Text = CurrentLang.AdminWarning(procName);
                        lbADMINORNOT.Visible = true;
                    }
                }));
            };

            LoadSettings();
            ApplyLanguage();
            UpdateCeilingLabel(CurrentLimitValue);
            UpdateDebounceLabel(CurrentDebounceValue);

            if (lbADMINORNOT != null)
            {
                lbADMINORNOT.Visible = false;
                lbADMINORNOT.Cursor = Cursors.Hand;
                lbADMINORNOT.Click += lbADMINORNOT_Click;
            }

            IsAppDisabledWhenCursorInside = cbDA.Checked;
            tbLimit.Enabled = cbAL.Checked;
            lbCPSLimit.Text = $"{tbLimit.Value} CPS";

            lbLiveLeft.Text = "0"; lbLiveRight.Text = "0";
            gaugeLeft.Value = 0; gaugeRight.Value = 0;

            _lastLogCeiling = CurrentLimitValue;
            _lastLogDebounce = CurrentDebounceValue;
            _lastLogLimit = tbLimit.Value;

            TrayManager.Initialize(TrayIcon, this, ForceExitApp);

            if (cbSH.Checked)
            {
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                BeginInvoke(new MethodInvoker(() => this.Hide()));
            }

            MouseHookManager.StartHook();
            ProcessMonitor.Start();

            Timer timerKeyCheck = new Timer { Interval = 50 };
            timerKeyCheck.Tick += TimerKeyCheck_Tick;
            timerKeyCheck.Start();

            TimerRealCPS.Interval = 25; TimerRealCPS.Start();
            TimerSmoothUI.Interval = 16; TimerSmoothUI.Start();
            TimerAntiFreeze.Interval = 1000; TimerAntiFreeze.Start();

            var myToggles = new Guna2ToggleSwitch[] { cbRS, cbSH, cbCU, cbTR, cbDA, cbAL, cbEK, cbLeft, cbRight, cbSA };
            foreach (var toggle in myToggles)
            {
                toggle.ShadowDecoration.Depth = 18;
                toggle.CheckedChanged -= ToggleShadow_CheckedChanged;
                toggle.CheckedChanged += ToggleShadow_CheckedChanged;
                toggle.ShadowDecoration.Enabled = toggle.Checked;
            }

            AppLogger.Log($"CPS Guard has been launched.");
            AppLogger.Log($"CPS Ceiling: set to {CurrentLimitValue} CPS.");
            AppLogger.Log($"Debounce Time: set to {CurrentDebounceValue} ms.");
            AppLogger.Log($"Limiting mode: set to {GetModeName()}.");

            _isInitializationComplete = true;

            tabMaster.TabMenuVisible = false;
            btnTab_main.Checked = true;
            UpdateNavigation();

            this.Opacity = 1;
            SaveAllSettings();

            _ = RunNetworkTasksAsync();
        }

        private async Task RunNetworkTasksAsync()
        {
            await Task.Delay(3000);
            await UpdateManager.FetchSocialLinksAsync();

            if (cbCU.Checked)
            {
                var updateInfo = await UpdateManager.CheckForUpdatesAsync();
                if (updateInfo.hasUpdate)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        AppLogger.Log($"Update: New version available: {updateInfo.newVersion}");
                        DialogResult result = MessageBox.Show(CurrentLang.UpdateAvailableMessage(updateInfo.newVersion), CurrentLang.UpdateAvailableTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (result == DialogResult.Yes) UpdateManager.OpenLink(UpdateManager.DOWNLOAD_URL);
                    });
                }
            }
        }

        #endregion

        #region 3. Événements UI

        private void ApplyLanguage()
        {
            if (lbRAS != null) lbRAS.Text = CurrentLang.RasText;
            if (lbSH != null) lbSH.Text = CurrentLang.StartHiddenText;
            if (lbMTT != null) lbMTT.Text = CurrentLang.TrayMinimizeText;
            if (lnDCOA != null) lnDCOA.Text = CurrentLang.DisableAppText;
            if (lbAOHCPS != null) lbAOHCPS.Text = CurrentLang.HighCPSAlertText;
            if (lbCU != null) lbCU.Text = CurrentLang.CheckUpdatesText;
            if (lbLC != null) lbLC.Text = CurrentLang.CountLeftText;
            if (lbRC != null) lbRC.Text = CurrentLang.CountRightText;
            if (lbTH != null) lbTH.Text = CurrentLang.ThresholdsText;
            if (lbDT != null) lbDT.Text = CurrentLang.DebounceTimeText;
            if (lbAB != null) lbAB.Text = CurrentLang.AppBehaviorText;
            if (lbM != null) lbM.Text = CurrentLang.MiscText;
            if (lbP != null) lbP.Text = CurrentLang.PreferencesText;
            if (lbKB != null) lbKB.Text = CurrentLang.KeybindingText;
            if (lSL != null) lSL.Text = CurrentLang.SelectedLanguageText;
            if (cbSaveLogs != null) cbSaveLogs.Text = CurrentLang.SaveLogsText;
            if (btnOpenLogs != null) btnOpenLogs.Text = CurrentLang.OpenLogsFolderText;
            if (lbSA != null) lbSA.Text = CurrentLang.SmartActivationText;

            if (lbADMINORNOT != null && !string.IsNullOrEmpty(_lastAdminProcName)) lbADMINORNOT.Text = CurrentLang.AdminWarning(_lastAdminProcName);

            if (btnTab_main != null) btnTab_main.Text = CurrentLang.TabMainText;
            if (btnTab_logs != null) btnTab_logs.Text = CurrentLang.TabLogsText;
            if (btnTab_settings != null) btnTab_settings.Text = CurrentLang.TabSettingsText;

            if (Guna2HtmlToolTip1 != null)
            {
                if (cbRS != null) Guna2HtmlToolTip1.SetToolTip(cbRS, CurrentLang.TooltipRS);
                if (lbRAS != null) Guna2HtmlToolTip1.SetToolTip(lbRAS, CurrentLang.TooltipRS);
                if (cbLeft != null) Guna2HtmlToolTip1.SetToolTip(cbLeft, CurrentLang.TooltipLeft);
                if (cbRight != null) Guna2HtmlToolTip1.SetToolTip(cbRight, CurrentLang.TooltipRight);
                if (btnGuard != null) Guna2HtmlToolTip1.SetToolTip(btnGuard, CurrentLang.TooltipGuard);
                if (tbCeiling != null) Guna2HtmlToolTip1.SetToolTip(tbCeiling, CurrentLang.TooltipCeiling);
                if (tbDebouncetime != null) Guna2HtmlToolTip1.SetToolTip(tbDebouncetime, CurrentLang.TooltipDebounce);
                if (btnSmartcut != null) Guna2HtmlToolTip1.SetToolTip(btnSmartcut, CurrentLang.TooltipSmartcut);
                if (btnHardcut != null) Guna2HtmlToolTip1.SetToolTip(btnHardcut, CurrentLang.TooltipHardcut);
                if (btnPulsecut != null) Guna2HtmlToolTip1.SetToolTip(btnPulsecut, CurrentLang.TooltipPulsecut);
                if (cbSH != null) Guna2HtmlToolTip1.SetToolTip(cbSH, CurrentLang.TooltipSH);
                if (cbCU != null) Guna2HtmlToolTip1.SetToolTip(cbCU, CurrentLang.TooltipCU);
                if (cbDA != null) Guna2HtmlToolTip1.SetToolTip(cbDA, CurrentLang.TooltipDA);
                if (cbTR != null) Guna2HtmlToolTip1.SetToolTip(cbTR, CurrentLang.TooltipTR);
                if (cbAL != null) Guna2HtmlToolTip1.SetToolTip(cbAL, CurrentLang.TooltipAL);
                if (tbLimit != null) Guna2HtmlToolTip1.SetToolTip(tbLimit, CurrentLang.TooltipLimit);
                if (btnKeybind != null) Guna2HtmlToolTip1.SetToolTip(btnKeybind, CurrentLang.TooltipKeybind);
                if (cbEK != null) Guna2HtmlToolTip1.SetToolTip(cbEK, CurrentLang.TooltipEK);
                if (cbSA != null) Guna2HtmlToolTip1.SetToolTip(cbSA, CurrentLang.TooltipSA);
                if (lbADMINORNOT != null) Guna2HtmlToolTip1.SetToolTip(lbADMINORNOT, CurrentLang.TooltipAdminRestart);
            }

            UpdateGuardVisuals(IsGuardActive);
            UpdateModeVisuals();
            UpdateKeybindButtonText();
        }

        private void cbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLanguage.SelectedIndex == 1) CurrentLang = new LangFR();
            else CurrentLang = new LangEN();

            if (_isInitializationComplete) AppLogger.Log($"Language changed to {(cbLanguage.SelectedIndex == 1 ? "Français" : "English")}.");
            ApplyLanguage();
            SaveAllSettings();
        }

        private void btnGuard_Click(object sender, EventArgs e)
        {
            bool newState = !IsGuardActive;
            UpdateGuardVisuals(newState);
            if (DetectionMode == 3 || DetectionMode == 2) CPSEngine.ResetEngine(CurrentLimitValue, CPSEngine.GlobalWatch.ElapsedMilliseconds);
            if (_isInitializationComplete) AppLogger.Log(newState ? "CPS Guard enabled." : "CPS Guard disabled.");
        }

        private void UpdateGuardVisuals(bool isActive)
        {
            IsGuardActive = isActive;
            btnGuard.Checked = isActive;
            if (isActive)
            {
                btnGuard.Text = CurrentLang.GuardEnabled;
                btnGuard.Image = Properties.Resources.shield_check;
                btnGuard.FillColor = Color.FromArgb(67, 203, 78);
                btnGuard.FillColor2 = Color.FromArgb(44, 182, 86);
            }
            else
            {
                btnGuard.Text = CurrentLang.GuardDisabled;
                btnGuard.Image = Properties.Resources.shield_xmark;
                btnGuard.FillColor = Color.DimGray;
                btnGuard.FillColor2 = Color.FromArgb(64, 64, 64);
            }
        }

        private void UpdateModeVisuals()
        {
            btnHardcut.ShadowDecoration.Enabled = false; btnHardcut.BorderThickness = 2;
            btnPulsecut.ShadowDecoration.Enabled = false; btnPulsecut.BorderThickness = 2;
            btnSmartcut.ShadowDecoration.Enabled = false; btnSmartcut.BorderThickness = 2;

            if (DetectionMode == 0)
            {
                btnHardcut.ShadowDecoration.Enabled = true; btnHardcut.BorderThickness = 3;
                lbLM.Text = CurrentLang.ModeHardTitle;
                lbLD.Text = CurrentLang.ModeHardDesc;
                lbMCC.Text = CurrentLang.MaxCeiling;
            }
            else if (DetectionMode == 2)
            {
                btnPulsecut.ShadowDecoration.Enabled = true; btnPulsecut.BorderThickness = 3;
                lbLM.Text = CurrentLang.ModePulseTitle;
                lbLD.Text = CurrentLang.ModePulseDesc;
                lbMCC.Text = CurrentLang.AverageCeiling;
            }
            else if (DetectionMode == 3)
            {
                btnSmartcut.ShadowDecoration.Enabled = true; btnSmartcut.BorderThickness = 3;
                lbLM.Text = CurrentLang.ModeSmartTitle;
                lbLD.Text = CurrentLang.ModeSmartDesc;
                lbMCC.Text = CurrentLang.AverageCeiling;
            }
        }

        private void btnHardcut_Click(object sender, EventArgs e)
        {
            if (DetectionMode == 0) return;
            DetectionMode = 0;
            UpdateModeVisuals();
            if (_isInitializationComplete) AppLogger.Log($"Limiting mode: set to {GetModeName()}.");
            SaveAllSettings();
        }

        private void btnPulsecut_Click(object sender, EventArgs e)
        {
            if (DetectionMode == 2) return;
            DetectionMode = 2;
            CPSEngine.ResetEngine(CurrentLimitValue, CPSEngine.GlobalWatch.ElapsedMilliseconds);
            UpdateModeVisuals();
            if (_isInitializationComplete) AppLogger.Log($"Limiting mode: set to {GetModeName()}.");
            SaveAllSettings();
        }

        private void btnSmartcut_Click(object sender, EventArgs e)
        {
            if (DetectionMode == 3) return;
            DetectionMode = 3;
            CPSEngine.ResetEngine(CurrentLimitValue, CPSEngine.GlobalWatch.ElapsedMilliseconds);
            UpdateModeVisuals();
            if (_isInitializationComplete) AppLogger.Log($"Limiting mode: set to {GetModeName()}.");
            SaveAllSettings();
        }

        private void UpdateNavigation()
        {
            btnTab_main.Image = Properties.Resources.main_off; btnTab_main.ForeColor = Color.FromArgb(139, 139, 139);
            btnTab_logs.Image = Properties.Resources.log_file_off; btnTab_logs.ForeColor = Color.FromArgb(139, 139, 139);
            btnTab_settings.Image = Properties.Resources.settings_sliders_off; btnTab_settings.ForeColor = Color.FromArgb(139, 139, 139);

            if (btnTab_main.Checked) { btnTab_main.Image = Properties.Resources.main_on; btnTab_main.ForeColor = Color.FromArgb(72, 239, 241); tabMaster.SelectedIndex = 0; }
            if (btnTab_logs.Checked) { btnTab_logs.Image = Properties.Resources.log_file_on; btnTab_logs.ForeColor = Color.FromArgb(72, 239, 241); tabMaster.SelectedIndex = 1; if (tbLogs.Text.Length > 0) { tbLogs.SelectionStart = tbLogs.Text.Length; tbLogs.ScrollToCaret(); } }
            if (btnTab_settings.Checked) { btnTab_settings.Image = Properties.Resources.settings_sliders_on; btnTab_settings.ForeColor = Color.FromArgb(72, 239, 241); tabMaster.SelectedIndex = 2; }
        }

        private void btnTab_main_Click(object sender, EventArgs e) => UpdateNavigation();
        private void btnTab_logs_Click(object sender, EventArgs e) => UpdateNavigation();
        private void btnTab_settings_Click(object sender, EventArgs e) => UpdateNavigation();

        private void ToggleShadow_CheckedChanged(object sender, EventArgs e)
        {
            Guna2ToggleSwitch toggle = (Guna2ToggleSwitch)sender;
            toggle.ShadowDecoration.Enabled = toggle.Checked;
        }

        private void tbCeiling_Scroll(object sender, ScrollEventArgs e) 
        { 
            CurrentLimitValue = tbCeiling.Value; UpdateCeilingLabel(CurrentLimitValue); 
        }

        private void tbDebouncetime_Scroll(object sender, ScrollEventArgs e) 
        {
            CurrentDebounceValue = tbDebouncetime.Value; UpdateDebounceLabel(CurrentDebounceValue); 
        
        }
        private void tbLimit_Scroll(object sender, ScrollEventArgs e) => lbCPSLimit.Text = $"{tbLimit.Value} CPS";
        private void UpdateCeilingLabel(int val) => lbCPSceiling.Text = $"{val} cps";
        private void UpdateDebounceLabel(int val) => lbDebounceMS.Text = $"{val} ms";

        private void tbCeiling_MouseUp(object sender, MouseEventArgs e) 
        { 
            if (tbCeiling.Value != _lastLogCeiling) 
            { 
                AppLogger.Log($"Max CPS Ceiling: set to {tbCeiling.Value} CPS."); 
                _lastLogCeiling = tbCeiling.Value; 
            } 
        }

        private void tbDebouncetime_MouseUp(object sender, MouseEventArgs e) 
        { 
            if (tbDebouncetime.Value != _lastLogDebounce) 
            { 
                AppLogger.Log($"Debounce Time: set to {tbDebouncetime.Value} ms."); 
                _lastLogDebounce = tbDebouncetime.Value; 
            } 
        }

        private void tbLimit_MouseUp(object sender, MouseEventArgs e) 
        { 
            if (tbLimit.Value != _lastLogLimit) 
            { AppLogger.Log($"Alert Limit set to {tbLimit.Value} CPS.");
                _lastLogLimit = tbLimit.Value; 
            } 
        }

        private void cbDisableApp_CheckedChanged(object sender, EventArgs e)
        {
            IsAppDisabledWhenCursorInside = cbDA.Checked;
            if (_isInitializationComplete) AppLogger.Log($"Disable inside app changed to {cbDA.Checked}");
        }

        private void cbAlert_CheckedChanged(object sender, EventArgs e)
        {
            tbLimit.Enabled = cbAL.Checked;

            if (_isInitializationComplete)
            {
                AppLogger.Log(cbAL.Checked ? "High CPS Alert enabled." : "High CPS Alert disabled.");
                if (cbAL.Checked && !AreWindowsNotificationsEnabled())
                {
                    MessageBox.Show(CurrentLang.NotificationsDisabledMessage, CurrentLang.NotificationsDisabledTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    AppLogger.Log("WARNING: User enabled alerts, but Windows notifications are disabled.");
                }
            }
        }

        private void cbLeft_CheckedChanged_1(object sender, EventArgs e)
        {
            if (!cbLeft.Checked && !cbRight.Checked) cbLeft.Checked = true;
            MouseHookManager.LimitLeftClick = cbLeft.Checked;
            if (_isInitializationComplete) AppLogger.Log(cbLeft.Checked ? "Left click counting enabled." : "Left click counting disabled.");
        }

        private void cbRight_CheckedChanged_1(object sender, EventArgs e)
        {
            if (!cbRight.Checked && !cbLeft.Checked) cbRight.Checked = true;
            MouseHookManager.LimitRightClick = cbRight.Checked;
            if (_isInitializationComplete) AppLogger.Log(cbRight.Checked ? "Right click counting enabled." : "Right click counting disabled.");
        }

        private void cbEKeybind_CheckedChanged(object sender, EventArgs e)
        {
            btnKeybind.Enabled = cbEK.Checked;
            MouseHookManager.KeybindActivationEnabled = cbEK.Checked;
            if (!cbEK.Checked && KeybindManager.IsBinding) KeybindManager.StopBinding();
            if (_isInitializationComplete) AppLogger.Log(cbEK.Checked ? "Keybind Activation enabled." : "Keybind Activation disabled.");
        }

        private void cbSA_CheckedChanged(object sender, EventArgs e) { if (_isInitializationComplete) AppLogger.Log(cbSA.Checked ? "Smart Activation enabled." : "Smart Activation disabled."); }
        private void cbSaveLogs_CheckedChanged(object sender, EventArgs e) { if (_isInitializationComplete) AppLogger.Log(cbSaveLogs.Checked ? "Auto-save logs enabled." : "Auto-save logs disabled."); }

        private void cbRunStartup_CheckedChanged(object sender, EventArgs e)
        {
            try { using (RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true)) { if (cbRS.Checked) { rk.SetValue("CPSGuard", Application.ExecutablePath); if (_isInitializationComplete) AppLogger.Log("Auto-start enabled."); } else { rk.DeleteValue("CPSGuard", false); if (_isInitializationComplete) AppLogger.Log("Auto-start disabled."); } } }
            catch { if (_isInitializationComplete) AppLogger.Log("ERROR: Permission denied for startup."); }
        }

        private void cbStartHidden_CheckedChanged(object sender, EventArgs e) { if (_isInitializationComplete) AppLogger.Log(cbSH.Checked ? "CPS Guard will start hidden." : "CPS Guard won't start hidden."); }
        private void cbTray_CheckedChanged(object sender, EventArgs e) { if (_isInitializationComplete) AppLogger.Log(cbTR.Checked ? "Tray minimize enabled." : "Tray minimize disabled."); }
        private void cbCheckUpdates_CheckedChanged(object sender, EventArgs e) { if (_isInitializationComplete) AppLogger.Log(cbCU.Checked ? "Updates enabled." : "Updates disabled."); }

        private void lbADMINORNOT_Click(object sender, EventArgs e)
        {
            AppLogger.Log("Restarting application with Administrator privileges...");

            SaveAllSettings();
            if (cbSaveLogs != null && cbSaveLogs.Checked) AppLogger.SaveLogsToFile(tbLogs.Text);

            try
            {
                ProcessStartInfo procInfo = new ProcessStartInfo();
                procInfo.UseShellExecute = true;
                procInfo.FileName = Application.ExecutablePath;
                procInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                procInfo.Verb = "runas";

                Process.Start(procInfo);
                MouseHookManager.StopHook();
                ProcessMonitor.Stop();
                Environment.Exit(0);
            }
            catch (System.ComponentModel.Win32Exception)
            {
                AppLogger.Log("Administrator restart cancelled by user.");
                MouseHookManager.StartHook();
                ProcessMonitor.Start();
            }
            catch (Exception ex)
            {
                AppLogger.Log($"Error restarting as Admin: {ex.Message}");
            }
        }

        private void picDiscord_Click(object sender, EventArgs e) { UpdateManager.OpenLink(UpdateManager.LinkDiscord); }
        private void picYT_Click(object sender, EventArgs e) { UpdateManager.OpenLink(UpdateManager.LinkYoutube); }
        private void picTiktok_Click(object sender, EventArgs e) { UpdateManager.OpenLink(UpdateManager.LinkTikTok); }

        private void guna2ImageButton1_Click(object sender, EventArgs e) { }
        private void guna2ShadowPanel4_Paint(object sender, PaintEventArgs e) { }

        #endregion

        #region 4. Timers (Calcul en temps réel)

        private void TimerRealCPS_Tick(object sender, EventArgs e)
        {
            long now = CPSEngine.GlobalWatch.ElapsedMilliseconds;
            long cutoff = now - 1000;

            if (DetectionMode == 2) CPSEngine.UpdatePulsePhase(CurrentLimitValue);

            int acceptedCPSLeft, totalRawCPSLeft, acceptedCPSRight, totalRawCPSRight;
            CPSEngine.CleanHistoryAndGetStats(cutoff, out acceptedCPSLeft, out totalRawCPSLeft, out acceptedCPSRight, out totalRawCPSRight);

            lbLiveLeft.ForeColor = (IsGuardActive && DetectionMode > 0 && acceptedCPSLeft > CurrentLimitValue) ? Color.FromArgb(255, 80, 80) : Color.White;
            lbLiveRight.ForeColor = (IsGuardActive && DetectionMode > 0 && acceptedCPSRight > CurrentLimitValue) ? Color.FromArgb(255, 80, 80) : Color.White;

            int currentMax = Math.Max(acceptedCPSLeft, acceptedCPSRight);
            if (currentMax > SessionInternalPeakCPS) SessionInternalPeakCPS = currentMax;

            if (!IsGuardActive && cbSA != null && cbSA.Checked && currentMax >= CurrentLimitValue)
            {
                this.BeginInvoke(new MethodInvoker(() => {
                    if (!IsGuardActive)
                    {
                        btnGuard_Click(null, null);
                        AppLogger.Log("Smart Activation: Guard enabled automatically.");
                    }
                }));
            }

            if (cbAL.Checked && (acceptedCPSLeft > tbLimit.Value || acceptedCPSRight > tbLimit.Value))
            {
                if ((DateTime.Now - _lastAlertTime).TotalSeconds > 5)
                {
                    string msg = acceptedCPSLeft > tbLimit.Value ? CurrentLang.AlertLeft(acceptedCPSLeft) : CurrentLang.AlertRight(acceptedCPSRight);
                    TrayManager.ShowNotification(CurrentLang.AlertLimitExceededTitle, CurrentLang.AlertLimitExceededMessage(msg), ToolTipIcon.Warning);
                    _lastAlertTime = DateTime.Now;
                    AppLogger.Log($"Alert: High CPS detected ({msg})");
                }
            }

            int removedLeft = totalRawCPSLeft - acceptedCPSLeft;
            lbRemovedCpsLeft.Text = removedLeft > 0 ? $"- {removedLeft} cps" : "";
            lbRemovedCpsLeft.Visible = removedLeft > 0;

            int removedRight = totalRawCPSRight - acceptedCPSRight;
            lbRemovedCpsRight.Text = removedRight > 0 ? $"- {removedRight} cps" : "";
            lbRemovedCpsRight.Visible = removedRight > 0;

            UpdateLiveCPSTarget(acceptedCPSLeft, acceptedCPSRight);
        }

        private void TimerSmoothUI_Tick(object sender, EventArgs e)
        {
            const double SPEED_FACTOR = 0.45;
            double maxVisualCPS = (double)CurrentLimitValue;
            if (maxVisualCPS < 8) maxVisualCPS = 8;

            _currentDisplayedLeft = _currentDisplayedLeft + (_targetCPSValueLeft - _currentDisplayedLeft) * SPEED_FACTOR;
            int percentLeft = (int)((_currentDisplayedLeft / maxVisualCPS) * 100);
            gaugeLeft.Value = Math.Max(0, Math.Min(100, percentLeft));

            _currentDisplayedRight = _currentDisplayedRight + (_targetCPSValueRight - _currentDisplayedRight) * SPEED_FACTOR;
            int percentRight = (int)((_currentDisplayedRight / maxVisualCPS) * 100);
            gaugeRight.Value = Math.Max(0, Math.Min(100, percentRight));
        }

        private void UpdateLiveCPSTarget(int cpsLeft, int cpsRight)
        {
            lbLiveLeft.Text = cpsLeft.ToString();
            lbLiveRight.Text = cpsRight.ToString();
            _targetCPSValueLeft = cpsLeft;
            _targetCPSValueRight = cpsRight;
        }

        private void TimerKeyCheck_Tick(object sender, EventArgs e)
        {
            KeybindManager.CheckPeriodicState(cbEK.Checked);
        }

        private void TimerAntiFreeze_Tick(object sender, EventArgs e) => _lastHeartbeatTime = DateTime.Now;

        #endregion

        #region 5. Gestion des Paramètres (Save/Load)

        private void LoadSettings()
        {
            AppConfig config = ConfigManager.Load();

            if (cbLanguage != null)
            {
                if (config.LanguageIndex >= 0 && config.LanguageIndex < cbLanguage.Items.Count) cbLanguage.SelectedIndex = config.LanguageIndex;
                else cbLanguage.SelectedIndex = 0;
                CurrentLang = cbLanguage.SelectedIndex == 1 ? (ILanguage)new LangFR() : new LangEN();
            }

            CurrentLimitValue = config.CeilingCPS;
            if (CurrentLimitValue < 8) CurrentLimitValue = 8;
            CurrentDebounceValue = config.DebounceMS;
            IsGuardActive = config.GuardState;

            cbRS.Checked = config.RunStartup;
            cbSH.Checked = config.StartHidden;
            cbTR.Checked = config.TrayMinimize;
            cbDA.Checked = config.DisableApp;
            cbAL.Checked = config.AlertActive;
            tbLimit.Value = config.AlertLimit;
            cbCU.Checked = config.CheckUpdates;
            cbLeft.Checked = config.LeftCount;
            cbRight.Checked = config.RightCount;
            cbEK.Checked = config.EnabledKeybind;
            cbSA.Checked = config.SmartActivation;

            KeybindManager.CurrentKeybind = (Keys)config.KeybindValue;

            cbSaveLogs.Checked = config.SavingLogs;
            tbCeiling.Value = CurrentLimitValue;
            tbDebouncetime.Value = CurrentDebounceValue;

            DetectionMode = config.DetectionMode;
            if (DetectionMode == 1) DetectionMode = 3;

            switch (DetectionMode)
            {
                case 2: btnPulsecut.Checked = true; break;
                case 3: btnSmartcut.Checked = true; break;
                case 0:
                default: btnHardcut.Checked = true; DetectionMode = 0; break;
            }

            MouseHookManager.LimitLeftClick = cbLeft.Checked;
            MouseHookManager.LimitRightClick = cbRight.Checked;
            MouseHookManager.KeybindActivationEnabled = cbEK.Checked;
        }

        private void SaveAllSettings()
        {
            AppConfig config = new AppConfig();
            config.CeilingCPS = tbCeiling.Value;
            config.DebounceMS = tbDebouncetime.Value;
            config.RunStartup = cbRS.Checked;
            config.StartHidden = cbSH.Checked;
            config.TrayMinimize = cbTR.Checked;
            config.DisableApp = cbDA.Checked;
            config.AlertActive = cbAL.Checked;
            config.AlertLimit = tbLimit.Value;
            config.CheckUpdates = cbCU.Checked;
            config.LeftCount = cbLeft.Checked;
            config.RightCount = cbRight.Checked;
            config.EnabledKeybind = cbEK.Checked;
            config.SmartActivation = cbSA.Checked;
            config.KeybindValue = (int)KeybindManager.CurrentKeybind;
            config.SavingLogs = cbSaveLogs.Checked;
            config.GuardState = IsGuardActive;
            config.DetectionMode = DetectionMode;
            config.ToleranceLevel = 2;
            config.CeilMode = false;
            if (cbLanguage != null) config.LanguageIndex = cbLanguage.SelectedIndex;

            ConfigManager.Save(config);
        }

        #endregion

        #region 6. Autres Logiques (Keybind, Logs, FormClosing)

        private bool AreWindowsNotificationsEnabled()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\PushNotifications"))
                {
                    if (key != null)
                    {
                        object value = key.GetValue("ToastEnabled");
                        if (value != null && Convert.ToInt32(value) == 0)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            catch
            {
                return true;
            }
        }

        private string GetModeName()
        {
            if (DetectionMode == 0) return "Hard Mode";
            if (DetectionMode == 2) return "Safe Mode";
            if (DetectionMode == 3) return "Smart Mode";
            return "Unknown";
        }

        private void btnKeybind_Click(object sender, EventArgs e)
        {
            if (KeybindManager.IsBinding) KeybindManager.StopBinding();
            else
            {
                btnKeybind.FillColor = Color.FromArgb(232, 68, 84);
                btnKeybind.FillColor2 = Color.FromArgb(252, 68, 94);
                KeybindManager.StartBinding();
            }
        }

        private void UpdateKeybindButtonText()
        {
            btnKeybind.Text = (KeybindManager.CurrentKeybind == Keys.None || (int)KeybindManager.CurrentKeybind == 0) ? CurrentLang.KeyNone : $"[{KeybindManager.CurrentKeybind}]";
        }

        // --- Réception des Logs ---
        private void AppLogger_OnLogAdded(string formattedMessage)
        {
            if (tbLogs.InvokeRequired) tbLogs.Invoke(new Action(() => AppendLogSafe(formattedMessage)));
            else AppendLogSafe(formattedMessage);
        }

        private void AppendLogSafe(string line) { tbLogs.AppendText(line); tbLogs.SelectionStart = tbLogs.Text.Length; tbLogs.ScrollToCaret(); }
        private void btnOpenLogs_Click(object sender, EventArgs e) { AppLogger.OpenLogsFolder(); }
        private void lbCred_Click(object sender, EventArgs e) { UpdateManager.OpenLink("https://github.com/7controversed/CPS-Guard.git"); }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (_isForceExiting)
            {
                MouseHookManager.StopHook();
                ProcessMonitor.Stop();
                return;
            }

            if (e.CloseReason == CloseReason.UserClosing && cbTR.Checked)
            {
                e.Cancel = true;
                TrayManager.MinimizeToTray(CurrentLang.TrayMinimizedMessage);
                return;
            }

            AppLogger.Log($"Session Peak CPS: {SessionInternalPeakCPS}");
            AppLogger.Log("CPS Guard has been closed.");
            SaveAllSettings();

            if (cbSaveLogs.Checked) AppLogger.SaveLogsToFile(tbLogs.Text);
            MouseHookManager.StopHook();
            ProcessMonitor.Stop();
        }

        public void ForceExitApp()
        {
            _isForceExiting = true;
            AppLogger.Log($"Session Peak CPS: {SessionInternalPeakCPS}");
            AppLogger.Log("CPS Guard has been closed from Tray.");
            SaveAllSettings();
            if (cbSaveLogs.Checked) AppLogger.SaveLogsToFile(tbLogs.Text);
            Application.Exit();
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_ENTERSIZEMOVE = 0x0231; const int WM_EXITSIZEMOVE = 0x0232;
            if (m.Msg == WM_ENTERSIZEMOVE) TimerSmoothUI.Stop(); else if (m.Msg == WM_EXITSIZEMOVE) TimerSmoothUI.Start();
            base.WndProc(ref m);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (KeybindManager.IsBinding)
            {
                e.SuppressKeyPress = true;
                Keys actualKey = KeybindManager.GetActualKey(e.KeyCode);

                if (actualKey == Keys.Escape)
                {
                    KeybindManager.ResetKeybind();
                    SaveAllSettings();
                    AppLogger.Log("Keybind: Keybind removed (None).");
                }
                else if (actualKey != Keys.LWin && actualKey != Keys.RWin)
                {
                    KeybindManager.SetKeybind(actualKey);
                    SaveAllSettings();
                    AppLogger.Log($"Keybind: New key set to [{actualKey}]");
                }
            }
        }

        #endregion

        
    }
}