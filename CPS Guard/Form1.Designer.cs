namespace CPS_Guard
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TimerAntiFreeze = new System.Windows.Forms.Timer(this.components);
            this.Guna2HtmlToolTip1 = new Guna.UI2.WinForms.Guna2HtmlToolTip();
            this.cbCheckUpdates = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.cbTray = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.cbStartHidden = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.cbRunStartup = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.tbLimit = new Guna.UI2.WinForms.Guna2TrackBar();
            this.cbAlert = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.cbDisableApp = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.btnGuard = new Guna.UI2.WinForms.Guna2GradientButton();
            this.tbDebouncetime = new Guna.UI2.WinForms.Guna2TrackBar();
            this.tbCeiling = new Guna.UI2.WinForms.Guna2TrackBar();
            this.btnKeybind = new Guna.UI2.WinForms.Guna2GradientButton();
            this.cbEKeybind = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.cbLeft = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.cbRight = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.lbLiveCPS = new System.Windows.Forms.Label();
            this.rbModeTolerant = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rbModeCutoff = new Guna.UI2.WinForms.Guna2RadioButton();
            this.tbTolerance = new Guna.UI2.WinForms.Guna2TrackBar();
            this.rbModePulse = new Guna.UI2.WinForms.Guna2RadioButton();
            this.btnOpenLogs = new Guna.UI2.WinForms.Guna2GradientButton();
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.lbAlertWarning = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbCU = new System.Windows.Forms.Label();
            this.btnYoutube = new Guna.UI2.WinForms.Guna2GradientButton();
            this.tabSet = new System.Windows.Forms.TabPage();
            this.lbGks = new System.Windows.Forms.Label();
            this.btnTiktok = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnDiscord = new Guna.UI2.WinForms.Guna2GradientButton();
            this.sep1 = new Guna.UI2.WinForms.Guna2Separator();
            this.lbCred = new System.Windows.Forms.Label();
            this.lbCPSLimit = new System.Windows.Forms.Label();
            this.lbAB = new System.Windows.Forms.Label();
            this.lbMTT = new System.Windows.Forms.Label();
            this.lbSH = new System.Windows.Forms.Label();
            this.lbRAS = new System.Windows.Forms.Label();
            this.lbCPST = new System.Windows.Forms.Label();
            this.lbCPSL = new System.Windows.Forms.Label();
            this.lbAOHCPS = new System.Windows.Forms.Label();
            this.lnDCOA = new System.Windows.Forms.Label();
            this.lbSettings = new System.Windows.Forms.Label();
            this.lbCL = new System.Windows.Forms.Label();
            this.tbLogs = new Guna.UI2.WinForms.Guna2TextBox();
            this.tabLogs = new System.Windows.Forms.TabPage();
            this.cbSaveLogs = new Guna.UI2.WinForms.Guna2CheckBox();
            this.lbCPSG = new System.Windows.Forms.Label();
            this.tabMaster = new Guna.UI2.WinForms.Guna2TabControl();
            this.tabGuard = new System.Windows.Forms.TabPage();
            this.pnl4 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.gaugeRight = new Guna.UI2.WinForms.Guna2RadialGauge();
            this.lbRemovedCpsRight = new System.Windows.Forms.Label();
            this.lbRemovedCpsLeft = new System.Windows.Forms.Label();
            this.gaugeLeft = new Guna.UI2.WinForms.Guna2RadialGauge();
            this.pnlUpdate = new Guna.UI2.WinForms.Guna2GradientButton();
            this.lbDebounceMS = new System.Windows.Forms.Label();
            this.lbCPSceiling = new System.Windows.Forms.Label();
            this.lbDT = new System.Windows.Forms.Label();
            this.lbMCC = new System.Windows.Forms.Label();
            this.tabModules = new System.Windows.Forms.TabPage();
            this.pnl3 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.lbCB = new System.Windows.Forms.Label();
            this.lbToleranceValue = new System.Windows.Forms.Label();
            this.lbSCT = new System.Windows.Forms.Label();
            this.lbCP = new System.Windows.Forms.Label();
            this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
            this.TimerRealCPS = new System.Windows.Forms.Timer(this.components);
            this.TimerSmoothUI = new System.Windows.Forms.Timer(this.components);
            this.tabSet.SuspendLayout();
            this.tabLogs.SuspendLayout();
            this.tabMaster.SuspendLayout();
            this.tabGuard.SuspendLayout();
            this.pnl4.SuspendLayout();
            this.tabModules.SuspendLayout();
            this.pnl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // TimerAntiFreeze
            // 
            this.TimerAntiFreeze.Interval = 500;
            this.TimerAntiFreeze.Tick += new System.EventHandler(this.TimerAntiFreeze_Tick);
            // 
            // Guna2HtmlToolTip1
            // 
            this.Guna2HtmlToolTip1.AllowLinksHandling = true;
            this.Guna2HtmlToolTip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(28)))));
            this.Guna2HtmlToolTip1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Guna2HtmlToolTip1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Guna2HtmlToolTip1.MaximumSize = new System.Drawing.Size(0, 0);
            this.Guna2HtmlToolTip1.TitleFont = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // cbCheckUpdates
            // 
            this.cbCheckUpdates.Animated = true;
            this.cbCheckUpdates.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.cbCheckUpdates.CheckedState.BorderThickness = 1;
            this.cbCheckUpdates.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(214)))), ((int)(((byte)(154)))));
            this.cbCheckUpdates.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.cbCheckUpdates.CheckedState.InnerColor = System.Drawing.Color.White;
            this.cbCheckUpdates.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbCheckUpdates.Location = new System.Drawing.Point(14, 114);
            this.cbCheckUpdates.Name = "cbCheckUpdates";
            this.cbCheckUpdates.Size = new System.Drawing.Size(46, 21);
            this.cbCheckUpdates.TabIndex = 39;
            this.Guna2HtmlToolTip1.SetToolTip(this.cbCheckUpdates, "Automatically check updates when the app is launched.");
            this.cbCheckUpdates.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.cbCheckUpdates.UncheckedState.BorderThickness = 1;
            this.cbCheckUpdates.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.cbCheckUpdates.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.cbCheckUpdates.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.cbCheckUpdates.CheckedChanged += new System.EventHandler(this.cbCheckUpdates_CheckedChanged);
            // 
            // cbTray
            // 
            this.cbTray.Animated = true;
            this.cbTray.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.cbTray.CheckedState.BorderThickness = 1;
            this.cbTray.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(214)))), ((int)(((byte)(154)))));
            this.cbTray.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.cbTray.CheckedState.InnerColor = System.Drawing.Color.White;
            this.cbTray.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbTray.Location = new System.Drawing.Point(14, 145);
            this.cbTray.Name = "cbTray";
            this.cbTray.Size = new System.Drawing.Size(46, 21);
            this.cbTray.TabIndex = 29;
            this.Guna2HtmlToolTip1.SetToolTip(this.cbTray, "Minimizes app to the system tray instead of closing it.");
            this.cbTray.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.cbTray.UncheckedState.BorderThickness = 1;
            this.cbTray.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.cbTray.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.cbTray.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.cbTray.CheckedChanged += new System.EventHandler(this.cbTray_CheckedChanged);
            // 
            // cbStartHidden
            // 
            this.cbStartHidden.Animated = true;
            this.cbStartHidden.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.cbStartHidden.CheckedState.BorderThickness = 1;
            this.cbStartHidden.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(214)))), ((int)(((byte)(154)))));
            this.cbStartHidden.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.cbStartHidden.CheckedState.InnerColor = System.Drawing.Color.White;
            this.cbStartHidden.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbStartHidden.Location = new System.Drawing.Point(175, 83);
            this.cbStartHidden.Name = "cbStartHidden";
            this.cbStartHidden.Size = new System.Drawing.Size(46, 21);
            this.cbStartHidden.TabIndex = 27;
            this.Guna2HtmlToolTip1.SetToolTip(this.cbStartHidden, "Starts the app minimized to the system tray.");
            this.cbStartHidden.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.cbStartHidden.UncheckedState.BorderThickness = 1;
            this.cbStartHidden.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.cbStartHidden.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.cbStartHidden.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.cbStartHidden.CheckedChanged += new System.EventHandler(this.cbStartHidden_CheckedChanged);
            // 
            // cbRunStartup
            // 
            this.cbRunStartup.Animated = true;
            this.cbRunStartup.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.cbRunStartup.CheckedState.BorderThickness = 1;
            this.cbRunStartup.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(214)))), ((int)(((byte)(154)))));
            this.cbRunStartup.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.cbRunStartup.CheckedState.InnerColor = System.Drawing.Color.White;
            this.cbRunStartup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbRunStartup.Location = new System.Drawing.Point(14, 83);
            this.cbRunStartup.Name = "cbRunStartup";
            this.cbRunStartup.Size = new System.Drawing.Size(46, 21);
            this.cbRunStartup.TabIndex = 25;
            this.Guna2HtmlToolTip1.SetToolTip(this.cbRunStartup, "Automatically runs the app on Windows startup.");
            this.cbRunStartup.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.cbRunStartup.UncheckedState.BorderThickness = 1;
            this.cbRunStartup.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.cbRunStartup.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.cbRunStartup.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.cbRunStartup.CheckedChanged += new System.EventHandler(this.cbRunStartup_CheckedChanged);
            // 
            // tbLimit
            // 
            this.tbLimit.BackColor = System.Drawing.Color.Transparent;
            this.tbLimit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbLimit.Enabled = false;
            this.tbLimit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tbLimit.Location = new System.Drawing.Point(101, 268);
            this.tbLimit.Maximum = 50;
            this.tbLimit.Minimum = 8;
            this.tbLimit.Name = "tbLimit";
            this.tbLimit.Size = new System.Drawing.Size(149, 23);
            this.tbLimit.Style = Guna.UI2.WinForms.Enums.TrackBarStyle.Metro;
            this.tbLimit.TabIndex = 23;
            this.tbLimit.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(189)))), ((int)(((byte)(235)))));
            this.Guna2HtmlToolTip1.SetToolTip(this.tbLimit, "Sets the physical CPS threshold that triggers the alert.");
            this.tbLimit.Value = 20;
            this.tbLimit.Scroll += new System.Windows.Forms.ScrollEventHandler(this.tbLimit_Scroll);
            this.tbLimit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbLimit_MouseUp);
            // 
            // cbAlert
            // 
            this.cbAlert.Animated = true;
            this.cbAlert.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.cbAlert.CheckedState.BorderThickness = 1;
            this.cbAlert.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(214)))), ((int)(((byte)(154)))));
            this.cbAlert.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.cbAlert.CheckedState.InnerColor = System.Drawing.Color.White;
            this.cbAlert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbAlert.Location = new System.Drawing.Point(14, 236);
            this.cbAlert.Name = "cbAlert";
            this.cbAlert.Size = new System.Drawing.Size(46, 21);
            this.cbAlert.TabIndex = 20;
            this.Guna2HtmlToolTip1.SetToolTip(this.cbAlert, "Enables a Windows notification if your physical click speed (Raw Input) exceeds t" +
        "he limit set below.");
            this.cbAlert.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.cbAlert.UncheckedState.BorderThickness = 1;
            this.cbAlert.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.cbAlert.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.cbAlert.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.cbAlert.CheckedChanged += new System.EventHandler(this.cbAlert_CheckedChanged);
            // 
            // cbDisableApp
            // 
            this.cbDisableApp.Animated = true;
            this.cbDisableApp.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.cbDisableApp.CheckedState.BorderThickness = 1;
            this.cbDisableApp.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(214)))), ((int)(((byte)(154)))));
            this.cbDisableApp.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.cbDisableApp.CheckedState.InnerColor = System.Drawing.Color.White;
            this.cbDisableApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbDisableApp.Location = new System.Drawing.Point(14, 205);
            this.cbDisableApp.Name = "cbDisableApp";
            this.cbDisableApp.Size = new System.Drawing.Size(46, 21);
            this.cbDisableApp.TabIndex = 16;
            this.Guna2HtmlToolTip1.SetToolTip(this.cbDisableApp, "Disables counting and blocking when the cursor is over the app.");
            this.cbDisableApp.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.cbDisableApp.UncheckedState.BorderThickness = 1;
            this.cbDisableApp.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.cbDisableApp.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.cbDisableApp.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.cbDisableApp.CheckedChanged += new System.EventHandler(this.cbDisableApp_CheckedChanged);
            // 
            // btnGuard
            // 
            this.btnGuard.Animated = true;
            this.btnGuard.BorderRadius = 8;
            this.btnGuard.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.btnGuard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuard.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGuard.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGuard.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGuard.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGuard.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGuard.FillColor = System.Drawing.Color.DimGray;
            this.btnGuard.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGuard.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuard.ForeColor = System.Drawing.Color.White;
            this.btnGuard.Image = global::CPS_Guard.Properties.Resources.shield_xmark;
            this.btnGuard.ImageSize = new System.Drawing.Size(13, 13);
            this.btnGuard.Location = new System.Drawing.Point(25, 365);
            this.btnGuard.Name = "btnGuard";
            this.btnGuard.Size = new System.Drawing.Size(150, 24);
            this.btnGuard.TabIndex = 37;
            this.btnGuard.Text = "Guard - Disabled";
            this.Guna2HtmlToolTip1.SetToolTip(this.btnGuard, "Enable or disable CPS Guard.");
            this.btnGuard.Click += new System.EventHandler(this.btnGuard_Click);
            // 
            // tbDebouncetime
            // 
            this.tbDebouncetime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbDebouncetime.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tbDebouncetime.Location = new System.Drawing.Point(25, 288);
            this.tbDebouncetime.Name = "tbDebouncetime";
            this.tbDebouncetime.Size = new System.Drawing.Size(325, 23);
            this.tbDebouncetime.TabIndex = 11;
            this.tbDebouncetime.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(189)))), ((int)(((byte)(235)))));
            this.Guna2HtmlToolTip1.SetToolTip(this.tbDebouncetime, "Filters out accidental hardware double-clicks (switch bounce).");
            this.tbDebouncetime.Value = 10;
            this.tbDebouncetime.Scroll += new System.Windows.Forms.ScrollEventHandler(this.tbDebouncetime_Scroll);
            this.tbDebouncetime.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbDebouncetime_MouseUp);
            // 
            // tbCeiling
            // 
            this.tbCeiling.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbCeiling.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tbCeiling.Location = new System.Drawing.Point(25, 230);
            this.tbCeiling.Maximum = 30;
            this.tbCeiling.Minimum = 4;
            this.tbCeiling.Name = "tbCeiling";
            this.tbCeiling.Size = new System.Drawing.Size(325, 23);
            this.tbCeiling.TabIndex = 9;
            this.tbCeiling.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(189)))), ((int)(((byte)(235)))));
            this.Guna2HtmlToolTip1.SetToolTip(this.tbCeiling, "Sets the absolute maximum clicks per second allowed.");
            this.tbCeiling.Value = 18;
            this.tbCeiling.Scroll += new System.Windows.Forms.ScrollEventHandler(this.tbCeiling_Scroll);
            this.tbCeiling.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbCeiling_MouseUp);
            // 
            // btnKeybind
            // 
            this.btnKeybind.Animated = true;
            this.btnKeybind.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.btnKeybind.BorderRadius = 4;
            this.btnKeybind.BorderThickness = 1;
            this.btnKeybind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKeybind.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnKeybind.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnKeybind.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnKeybind.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnKeybind.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnKeybind.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnKeybind.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.btnKeybind.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeybind.ForeColor = System.Drawing.Color.White;
            this.btnKeybind.ImageSize = new System.Drawing.Size(13, 13);
            this.btnKeybind.Location = new System.Drawing.Point(235, 328);
            this.btnKeybind.Name = "btnKeybind";
            this.btnKeybind.Size = new System.Drawing.Size(132, 24);
            this.btnKeybind.TabIndex = 44;
            this.btnKeybind.Text = "[None]";
            this.btnKeybind.TextOffset = new System.Drawing.Point(1, 0);
            this.Guna2HtmlToolTip1.SetToolTip(this.btnKeybind, "Select a keybind. Press \'ESC\' for \"None\".");
            this.btnKeybind.Click += new System.EventHandler(this.btnKeybind_Click);
            // 
            // cbEKeybind
            // 
            this.cbEKeybind.Animated = true;
            this.cbEKeybind.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.cbEKeybind.CheckedState.BorderThickness = 1;
            this.cbEKeybind.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(214)))), ((int)(((byte)(154)))));
            this.cbEKeybind.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.cbEKeybind.CheckedState.InnerColor = System.Drawing.Color.White;
            this.cbEKeybind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbEKeybind.Location = new System.Drawing.Point(14, 329);
            this.cbEKeybind.Name = "cbEKeybind";
            this.cbEKeybind.Size = new System.Drawing.Size(46, 21);
            this.cbEKeybind.TabIndex = 45;
            this.Guna2HtmlToolTip1.SetToolTip(this.cbEKeybind, "Enable the keybinding activation/deactivation system.");
            this.cbEKeybind.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.cbEKeybind.UncheckedState.BorderThickness = 1;
            this.cbEKeybind.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.cbEKeybind.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.cbEKeybind.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.cbEKeybind.CheckedChanged += new System.EventHandler(this.cbEKeybind_CheckedChanged);
            // 
            // cbLeft
            // 
            this.cbLeft.Animated = true;
            this.cbLeft.AutoRoundedCorners = true;
            this.cbLeft.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.cbLeft.CheckedState.BorderRadius = 8;
            this.cbLeft.CheckedState.BorderThickness = 1;
            this.cbLeft.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(189)))), ((int)(((byte)(235)))));
            this.cbLeft.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.cbLeft.CheckedState.InnerBorderRadius = 4;
            this.cbLeft.CheckedState.InnerColor = System.Drawing.Color.White;
            this.cbLeft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbLeft.Location = new System.Drawing.Point(69, 164);
            this.cbLeft.Name = "cbLeft";
            this.cbLeft.Size = new System.Drawing.Size(41, 19);
            this.cbLeft.TabIndex = 46;
            this.Guna2HtmlToolTip1.SetToolTip(this.cbLeft, "Enable or disable left click counting.");
            this.cbLeft.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.cbLeft.UncheckedState.BorderRadius = 8;
            this.cbLeft.UncheckedState.BorderThickness = 1;
            this.cbLeft.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.cbLeft.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.cbLeft.UncheckedState.InnerBorderRadius = 4;
            this.cbLeft.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.cbLeft.CheckedChanged += new System.EventHandler(this.cbLeft_CheckedChanged_1);
            // 
            // cbRight
            // 
            this.cbRight.Animated = true;
            this.cbRight.AutoRoundedCorners = true;
            this.cbRight.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.cbRight.CheckedState.BorderRadius = 8;
            this.cbRight.CheckedState.BorderThickness = 1;
            this.cbRight.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(189)))), ((int)(((byte)(235)))));
            this.cbRight.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.cbRight.CheckedState.InnerBorderRadius = 4;
            this.cbRight.CheckedState.InnerColor = System.Drawing.Color.White;
            this.cbRight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbRight.Location = new System.Drawing.Point(265, 164);
            this.cbRight.Name = "cbRight";
            this.cbRight.Size = new System.Drawing.Size(41, 19);
            this.cbRight.TabIndex = 47;
            this.Guna2HtmlToolTip1.SetToolTip(this.cbRight, "Enable or disable right click counting.");
            this.cbRight.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.cbRight.UncheckedState.BorderRadius = 8;
            this.cbRight.UncheckedState.BorderThickness = 1;
            this.cbRight.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.cbRight.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.cbRight.UncheckedState.InnerBorderRadius = 4;
            this.cbRight.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.cbRight.CheckedChanged += new System.EventHandler(this.cbRight_CheckedChanged_1);
            // 
            // lbLiveCPS
            // 
            this.lbLiveCPS.BackColor = System.Drawing.Color.Transparent;
            this.lbLiveCPS.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLiveCPS.ForeColor = System.Drawing.Color.White;
            this.lbLiveCPS.Location = new System.Drawing.Point(5, 156);
            this.lbLiveCPS.Name = "lbLiveCPS";
            this.lbLiveCPS.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbLiveCPS.Size = new System.Drawing.Size(367, 32);
            this.lbLiveCPS.TabIndex = 43;
            this.lbLiveCPS.Text = "0";
            this.lbLiveCPS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Guna2HtmlToolTip1.SetToolTip(this.lbLiveCPS, "Enable or disable left click counting.");
            // 
            // rbModeTolerant
            // 
            this.rbModeTolerant.Animated = true;
            this.rbModeTolerant.AutoSize = true;
            this.rbModeTolerant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.rbModeTolerant.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbModeTolerant.CheckedState.BorderThickness = 0;
            this.rbModeTolerant.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbModeTolerant.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbModeTolerant.CheckedState.InnerOffset = -4;
            this.rbModeTolerant.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbModeTolerant.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbModeTolerant.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.rbModeTolerant.Location = new System.Drawing.Point(155, 81);
            this.rbModeTolerant.Name = "rbModeTolerant";
            this.rbModeTolerant.Size = new System.Drawing.Size(72, 21);
            this.rbModeTolerant.TabIndex = 49;
            this.rbModeTolerant.Text = "Soft Cut";
            this.Guna2HtmlToolTip1.SetToolTip(this.rbModeTolerant, "Allows slight CPS bursts above the limit to simulate human imperfection.");
            this.rbModeTolerant.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbModeTolerant.UncheckedState.BorderThickness = 2;
            this.rbModeTolerant.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbModeTolerant.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbModeTolerant.UseVisualStyleBackColor = false;
            this.rbModeTolerant.CheckedChanged += new System.EventHandler(this.rbModeTolerant_CheckedChanged);
            // 
            // rbModeCutoff
            // 
            this.rbModeCutoff.Animated = true;
            this.rbModeCutoff.AutoSize = true;
            this.rbModeCutoff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.rbModeCutoff.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbModeCutoff.CheckedState.BorderThickness = 0;
            this.rbModeCutoff.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbModeCutoff.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbModeCutoff.CheckedState.InnerOffset = -4;
            this.rbModeCutoff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbModeCutoff.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbModeCutoff.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.rbModeCutoff.Location = new System.Drawing.Point(25, 81);
            this.rbModeCutoff.Name = "rbModeCutoff";
            this.rbModeCutoff.Size = new System.Drawing.Size(78, 21);
            this.rbModeCutoff.TabIndex = 48;
            this.rbModeCutoff.Text = "Hard Cut";
            this.Guna2HtmlToolTip1.SetToolTip(this.rbModeCutoff, "Blocks clicks immediately once the CPS limit is reached.");
            this.rbModeCutoff.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbModeCutoff.UncheckedState.BorderThickness = 2;
            this.rbModeCutoff.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbModeCutoff.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbModeCutoff.UseVisualStyleBackColor = false;
            this.rbModeCutoff.CheckedChanged += new System.EventHandler(this.rbModeCutoff_CheckedChanged);
            // 
            // tbTolerance
            // 
            this.tbTolerance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbTolerance.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tbTolerance.Location = new System.Drawing.Point(151, 113);
            this.tbTolerance.Maximum = 5;
            this.tbTolerance.Minimum = 1;
            this.tbTolerance.Name = "tbTolerance";
            this.tbTolerance.Size = new System.Drawing.Size(140, 23);
            this.tbTolerance.Style = Guna.UI2.WinForms.Enums.TrackBarStyle.Metro;
            this.tbTolerance.TabIndex = 9;
            this.tbTolerance.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(189)))), ((int)(((byte)(235)))));
            this.Guna2HtmlToolTip1.SetToolTip(this.tbTolerance, "Sets the allowed burst range above the limit before the hard lock engages.");
            this.tbTolerance.Value = 1;
            this.tbTolerance.Scroll += new System.Windows.Forms.ScrollEventHandler(this.tbTolerance_Scroll);
            this.tbTolerance.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbTolerance_MouseUp);
            // 
            // rbModePulse
            // 
            this.rbModePulse.Animated = true;
            this.rbModePulse.AutoSize = true;
            this.rbModePulse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.rbModePulse.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbModePulse.CheckedState.BorderThickness = 0;
            this.rbModePulse.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbModePulse.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbModePulse.CheckedState.InnerOffset = -4;
            this.rbModePulse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbModePulse.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbModePulse.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.rbModePulse.Location = new System.Drawing.Point(276, 81);
            this.rbModePulse.Name = "rbModePulse";
            this.rbModePulse.Size = new System.Drawing.Size(79, 21);
            this.rbModePulse.TabIndex = 54;
            this.rbModePulse.Text = "Pulse Cut";
            this.Guna2HtmlToolTip1.SetToolTip(this.rbModePulse, "Continuously varies the limit in a rhythmic pattern to mimic natural organic fluc" +
        "tuation.");
            this.rbModePulse.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbModePulse.UncheckedState.BorderThickness = 2;
            this.rbModePulse.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbModePulse.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbModePulse.UseVisualStyleBackColor = false;
            this.rbModePulse.CheckedChanged += new System.EventHandler(this.rbModePulse_CheckedChanged);
            // 
            // btnOpenLogs
            // 
            this.btnOpenLogs.Animated = true;
            this.btnOpenLogs.BorderRadius = 8;
            this.btnOpenLogs.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.btnOpenLogs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenLogs.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnOpenLogs.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnOpenLogs.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnOpenLogs.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnOpenLogs.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnOpenLogs.FillColor = System.Drawing.Color.DimGray;
            this.btnOpenLogs.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnOpenLogs.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenLogs.ForeColor = System.Drawing.Color.White;
            this.btnOpenLogs.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenLogs.Image")));
            this.btnOpenLogs.ImageSize = new System.Drawing.Size(13, 13);
            this.btnOpenLogs.Location = new System.Drawing.Point(7, 404);
            this.btnOpenLogs.Name = "btnOpenLogs";
            this.btnOpenLogs.Size = new System.Drawing.Size(150, 24);
            this.btnOpenLogs.TabIndex = 38;
            this.btnOpenLogs.Text = "Open logs folder";
            this.btnOpenLogs.Click += new System.EventHandler(this.btnOpenLogs_Click);
            // 
            // TrayIcon
            // 
            this.TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
            this.TrayIcon.Text = "CPS Guard";
            this.TrayIcon.Visible = true;
            this.TrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseDoubleClick);
            // 
            // lbAlertWarning
            // 
            this.lbAlertWarning.AutoSize = false;
            this.lbAlertWarning.BackColor = System.Drawing.Color.Transparent;
            this.lbAlertWarning.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAlertWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(79)))), ((int)(((byte)(82)))));
            this.lbAlertWarning.IsSelectionEnabled = false;
            this.lbAlertWarning.Location = new System.Drawing.Point(16, 297);
            this.lbAlertWarning.Name = "lbAlertWarning";
            this.lbAlertWarning.Size = new System.Drawing.Size(327, 21);
            this.lbAlertWarning.TabIndex = 41;
            this.lbAlertWarning.Text = "⚠️ Windows Notifications are disabled!";
            this.lbAlertWarning.TextAlignment = System.Drawing.ContentAlignment.BottomLeft;
            this.lbAlertWarning.Visible = false;
            // 
            // lbCU
            // 
            this.lbCU.BackColor = System.Drawing.Color.Transparent;
            this.lbCU.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCU.ForeColor = System.Drawing.Color.White;
            this.lbCU.Location = new System.Drawing.Point(66, 114);
            this.lbCU.Name = "lbCU";
            this.lbCU.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbCU.Size = new System.Drawing.Size(184, 21);
            this.lbCU.TabIndex = 40;
            this.lbCU.Text = "Check for updates at launch";
            this.lbCU.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnYoutube
            // 
            this.btnYoutube.Animated = true;
            this.btnYoutube.BorderRadius = 5;
            this.btnYoutube.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYoutube.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnYoutube.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnYoutube.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnYoutube.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnYoutube.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnYoutube.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(189)))), ((int)(((byte)(235)))));
            this.btnYoutube.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(189)))), ((int)(((byte)(235)))));
            this.btnYoutube.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYoutube.ForeColor = System.Drawing.Color.White;
            this.btnYoutube.Image = ((System.Drawing.Image)(resources.GetObject("btnYoutube.Image")));
            this.btnYoutube.ImageSize = new System.Drawing.Size(13, 13);
            this.btnYoutube.Location = new System.Drawing.Point(141, 378);
            this.btnYoutube.Name = "btnYoutube";
            this.btnYoutube.Size = new System.Drawing.Size(99, 24);
            this.btnYoutube.TabIndex = 38;
            this.btnYoutube.Text = "YouTube";
            this.btnYoutube.TextOffset = new System.Drawing.Point(1, 0);
            this.btnYoutube.Click += new System.EventHandler(this.btnYoutube_Click);
            // 
            // tabSet
            // 
            this.tabSet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.tabSet.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabSet.BackgroundImage")));
            this.tabSet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tabSet.Controls.Add(this.lbGks);
            this.tabSet.Controls.Add(this.cbEKeybind);
            this.tabSet.Controls.Add(this.btnKeybind);
            this.tabSet.Controls.Add(this.lbAlertWarning);
            this.tabSet.Controls.Add(this.lbCU);
            this.tabSet.Controls.Add(this.cbCheckUpdates);
            this.tabSet.Controls.Add(this.btnYoutube);
            this.tabSet.Controls.Add(this.btnTiktok);
            this.tabSet.Controls.Add(this.btnDiscord);
            this.tabSet.Controls.Add(this.sep1);
            this.tabSet.Controls.Add(this.lbCred);
            this.tabSet.Controls.Add(this.lbCPSLimit);
            this.tabSet.Controls.Add(this.lbAB);
            this.tabSet.Controls.Add(this.lbMTT);
            this.tabSet.Controls.Add(this.cbTray);
            this.tabSet.Controls.Add(this.lbSH);
            this.tabSet.Controls.Add(this.cbStartHidden);
            this.tabSet.Controls.Add(this.lbRAS);
            this.tabSet.Controls.Add(this.cbRunStartup);
            this.tabSet.Controls.Add(this.lbCPST);
            this.tabSet.Controls.Add(this.tbLimit);
            this.tabSet.Controls.Add(this.lbCPSL);
            this.tabSet.Controls.Add(this.lbAOHCPS);
            this.tabSet.Controls.Add(this.cbAlert);
            this.tabSet.Controls.Add(this.lnDCOA);
            this.tabSet.Controls.Add(this.cbDisableApp);
            this.tabSet.Controls.Add(this.lbSettings);
            this.tabSet.ImageIndex = 1;
            this.tabSet.Location = new System.Drawing.Point(4, 64);
            this.tabSet.Name = "tabSet";
            this.tabSet.Padding = new System.Windows.Forms.Padding(3);
            this.tabSet.Size = new System.Drawing.Size(383, 433);
            this.tabSet.TabIndex = 1;
            // 
            // lbGks
            // 
            this.lbGks.BackColor = System.Drawing.Color.Transparent;
            this.lbGks.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGks.ForeColor = System.Drawing.Color.White;
            this.lbGks.Location = new System.Drawing.Point(66, 326);
            this.lbGks.Name = "lbGks";
            this.lbGks.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbGks.Size = new System.Drawing.Size(163, 24);
            this.lbGks.TabIndex = 46;
            this.lbGks.Text = "Guard keybinding system";
            this.lbGks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnTiktok
            // 
            this.btnTiktok.Animated = true;
            this.btnTiktok.BorderRadius = 5;
            this.btnTiktok.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTiktok.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTiktok.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTiktok.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTiktok.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTiktok.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTiktok.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(189)))), ((int)(((byte)(235)))));
            this.btnTiktok.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnTiktok.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnTiktok.ForeColor = System.Drawing.Color.White;
            this.btnTiktok.Image = ((System.Drawing.Image)(resources.GetObject("btnTiktok.Image")));
            this.btnTiktok.ImageSize = new System.Drawing.Size(13, 13);
            this.btnTiktok.Location = new System.Drawing.Point(268, 378);
            this.btnTiktok.Name = "btnTiktok";
            this.btnTiktok.Size = new System.Drawing.Size(99, 24);
            this.btnTiktok.TabIndex = 37;
            this.btnTiktok.Text = "TikTok";
            this.btnTiktok.TextOffset = new System.Drawing.Point(1, 0);
            this.btnTiktok.Click += new System.EventHandler(this.btnTiktok_Click);
            // 
            // btnDiscord
            // 
            this.btnDiscord.Animated = true;
            this.btnDiscord.BorderRadius = 5;
            this.btnDiscord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDiscord.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDiscord.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDiscord.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDiscord.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDiscord.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDiscord.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(189)))), ((int)(((byte)(235)))));
            this.btnDiscord.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiscord.ForeColor = System.Drawing.Color.White;
            this.btnDiscord.Image = ((System.Drawing.Image)(resources.GetObject("btnDiscord.Image")));
            this.btnDiscord.ImageSize = new System.Drawing.Size(13, 13);
            this.btnDiscord.Location = new System.Drawing.Point(14, 378);
            this.btnDiscord.Name = "btnDiscord";
            this.btnDiscord.Size = new System.Drawing.Size(99, 24);
            this.btnDiscord.TabIndex = 36;
            this.btnDiscord.Text = "Discord";
            this.btnDiscord.TextOffset = new System.Drawing.Point(1, 0);
            this.btnDiscord.Click += new System.EventHandler(this.btnDiscord_Click);
            // 
            // sep1
            // 
            this.sep1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.sep1.Location = new System.Drawing.Point(14, 358);
            this.sep1.Name = "sep1";
            this.sep1.Size = new System.Drawing.Size(353, 10);
            this.sep1.TabIndex = 34;
            // 
            // lbCred
            // 
            this.lbCred.BackColor = System.Drawing.Color.Transparent;
            this.lbCred.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbCred.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCred.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lbCred.Location = new System.Drawing.Point(3, 411);
            this.lbCred.Name = "lbCred";
            this.lbCred.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbCred.Size = new System.Drawing.Size(377, 24);
            this.lbCred.TabIndex = 33;
            this.lbCred.Text = "BLSquad - CPS Guard (1.2), by Controversed";
            this.lbCred.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbCred.Click += new System.EventHandler(this.lbCred_Click);
            // 
            // lbCPSLimit
            // 
            this.lbCPSLimit.BackColor = System.Drawing.Color.Transparent;
            this.lbCPSLimit.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCPSLimit.ForeColor = System.Drawing.Color.White;
            this.lbCPSLimit.Location = new System.Drawing.Point(256, 268);
            this.lbCPSLimit.Name = "lbCPSLimit";
            this.lbCPSLimit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbCPSLimit.Size = new System.Drawing.Size(23, 23);
            this.lbCPSLimit.TabIndex = 32;
            this.lbCPSLimit.Text = "20";
            this.lbCPSLimit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbAB
            // 
            this.lbAB.BackColor = System.Drawing.Color.Transparent;
            this.lbAB.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAB.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lbAB.Location = new System.Drawing.Point(13, 51);
            this.lbAB.Name = "lbAB";
            this.lbAB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbAB.Size = new System.Drawing.Size(182, 23);
            this.lbAB.TabIndex = 31;
            this.lbAB.Text = "APPLICATION BEHAVIOR";
            this.lbAB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMTT
            // 
            this.lbMTT.BackColor = System.Drawing.Color.Transparent;
            this.lbMTT.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMTT.ForeColor = System.Drawing.Color.White;
            this.lbMTT.Location = new System.Drawing.Point(66, 145);
            this.lbMTT.Name = "lbMTT";
            this.lbMTT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbMTT.Size = new System.Drawing.Size(163, 21);
            this.lbMTT.TabIndex = 30;
            this.lbMTT.Text = "Minimize to tray on close";
            this.lbMTT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbSH
            // 
            this.lbSH.BackColor = System.Drawing.Color.Transparent;
            this.lbSH.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSH.ForeColor = System.Drawing.Color.White;
            this.lbSH.Location = new System.Drawing.Point(227, 83);
            this.lbSH.Name = "lbSH";
            this.lbSH.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbSH.Size = new System.Drawing.Size(91, 21);
            this.lbSH.TabIndex = 28;
            this.lbSH.Text = "Start hidden";
            this.lbSH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbRAS
            // 
            this.lbRAS.BackColor = System.Drawing.Color.Transparent;
            this.lbRAS.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRAS.ForeColor = System.Drawing.Color.White;
            this.lbRAS.Location = new System.Drawing.Point(66, 83);
            this.lbRAS.Name = "lbRAS";
            this.lbRAS.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbRAS.Size = new System.Drawing.Size(98, 21);
            this.lbRAS.TabIndex = 26;
            this.lbRAS.Text = "Run at startup";
            this.lbRAS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbCPST
            // 
            this.lbCPST.BackColor = System.Drawing.Color.Transparent;
            this.lbCPST.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCPST.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lbCPST.Location = new System.Drawing.Point(13, 173);
            this.lbCPST.Name = "lbCPST";
            this.lbCPST.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbCPST.Size = new System.Drawing.Size(112, 23);
            this.lbCPST.TabIndex = 24;
            this.lbCPST.Text = "CPS TRACKING";
            this.lbCPST.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbCPSL
            // 
            this.lbCPSL.BackColor = System.Drawing.Color.Transparent;
            this.lbCPSL.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCPSL.ForeColor = System.Drawing.Color.White;
            this.lbCPSL.Location = new System.Drawing.Point(14, 266);
            this.lbCPSL.Name = "lbCPSL";
            this.lbCPSL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbCPSL.Size = new System.Drawing.Size(81, 23);
            this.lbCPSL.TabIndex = 22;
            this.lbCPSL.Text = "CPS Alert";
            this.lbCPSL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbAOHCPS
            // 
            this.lbAOHCPS.BackColor = System.Drawing.Color.Transparent;
            this.lbAOHCPS.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAOHCPS.ForeColor = System.Drawing.Color.White;
            this.lbAOHCPS.Location = new System.Drawing.Point(66, 236);
            this.lbAOHCPS.Name = "lbAOHCPS";
            this.lbAOHCPS.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbAOHCPS.Size = new System.Drawing.Size(118, 21);
            this.lbAOHCPS.TabIndex = 21;
            this.lbAOHCPS.Text = "Alert on high CPS";
            this.lbAOHCPS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lnDCOA
            // 
            this.lnDCOA.BackColor = System.Drawing.Color.Transparent;
            this.lnDCOA.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnDCOA.ForeColor = System.Drawing.Color.White;
            this.lnDCOA.Location = new System.Drawing.Point(66, 205);
            this.lnDCOA.Name = "lnDCOA";
            this.lnDCOA.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lnDCOA.Size = new System.Drawing.Size(211, 21);
            this.lnDCOA.TabIndex = 17;
            this.lnDCOA.Text = "Disable counter over app window";
            this.lnDCOA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbSettings
            // 
            this.lbSettings.BackColor = System.Drawing.Color.Transparent;
            this.lbSettings.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSettings.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbSettings.Location = new System.Drawing.Point(3, 20);
            this.lbSettings.Name = "lbSettings";
            this.lbSettings.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbSettings.Size = new System.Drawing.Size(377, 24);
            this.lbSettings.TabIndex = 7;
            this.lbSettings.Text = "Settings";
            this.lbSettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCL
            // 
            this.lbCL.BackColor = System.Drawing.Color.Transparent;
            this.lbCL.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCL.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbCL.Location = new System.Drawing.Point(3, 20);
            this.lbCL.Name = "lbCL";
            this.lbCL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbCL.Size = new System.Drawing.Size(377, 24);
            this.lbCL.TabIndex = 8;
            this.lbCL.Text = "Console Logs";
            this.lbCL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbLogs
            // 
            this.tbLogs.Animated = true;
            this.tbLogs.BorderRadius = 8;
            this.tbLogs.BorderThickness = 0;
            this.tbLogs.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbLogs.DefaultText = "";
            this.tbLogs.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbLogs.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbLogs.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbLogs.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbLogs.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.tbLogs.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbLogs.Font = new System.Drawing.Font("Nirmala Text", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLogs.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.tbLogs.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbLogs.Location = new System.Drawing.Point(5, 52);
            this.tbLogs.Multiline = true;
            this.tbLogs.Name = "tbLogs";
            this.tbLogs.PlaceholderText = "";
            this.tbLogs.ReadOnly = true;
            this.tbLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLogs.SelectedText = "";
            this.tbLogs.Size = new System.Drawing.Size(374, 343);
            this.tbLogs.TabIndex = 0;
            // 
            // tabLogs
            // 
            this.tabLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.tabLogs.Controls.Add(this.cbSaveLogs);
            this.tabLogs.Controls.Add(this.btnOpenLogs);
            this.tabLogs.Controls.Add(this.lbCL);
            this.tabLogs.Controls.Add(this.tbLogs);
            this.tabLogs.ImageIndex = 2;
            this.tabLogs.Location = new System.Drawing.Point(4, 64);
            this.tabLogs.Name = "tabLogs";
            this.tabLogs.Size = new System.Drawing.Size(383, 433);
            this.tabLogs.TabIndex = 2;
            // 
            // cbSaveLogs
            // 
            this.cbSaveLogs.Animated = true;
            this.cbSaveLogs.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.cbSaveLogs.CheckedState.BorderRadius = 2;
            this.cbSaveLogs.CheckedState.BorderThickness = 1;
            this.cbSaveLogs.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(214)))), ((int)(((byte)(154)))));
            this.cbSaveLogs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbSaveLogs.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSaveLogs.ForeColor = System.Drawing.Color.White;
            this.cbSaveLogs.Location = new System.Drawing.Point(251, 404);
            this.cbSaveLogs.Name = "cbSaveLogs";
            this.cbSaveLogs.Size = new System.Drawing.Size(128, 24);
            this.cbSaveLogs.TabIndex = 39;
            this.cbSaveLogs.Text = "Save logs as files";
            this.cbSaveLogs.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.cbSaveLogs.UncheckedState.BorderRadius = 2;
            this.cbSaveLogs.UncheckedState.BorderThickness = 1;
            this.cbSaveLogs.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.cbSaveLogs.CheckedChanged += new System.EventHandler(this.cbSaveLogs_CheckedChanged);
            // 
            // lbCPSG
            // 
            this.lbCPSG.BackColor = System.Drawing.Color.Transparent;
            this.lbCPSG.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCPSG.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbCPSG.Location = new System.Drawing.Point(0, 14);
            this.lbCPSG.Name = "lbCPSG";
            this.lbCPSG.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbCPSG.Size = new System.Drawing.Size(377, 24);
            this.lbCPSG.TabIndex = 6;
            this.lbCPSG.Text = "Live CPS";
            this.lbCPSG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabMaster
            // 
            this.tabMaster.Controls.Add(this.tabGuard);
            this.tabMaster.Controls.Add(this.tabModules);
            this.tabMaster.Controls.Add(this.tabLogs);
            this.tabMaster.Controls.Add(this.tabSet);
            this.tabMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMaster.ImageList = this.ImageList1;
            this.tabMaster.ItemSize = new System.Drawing.Size(70, 60);
            this.tabMaster.Location = new System.Drawing.Point(0, 0);
            this.tabMaster.Name = "tabMaster";
            this.tabMaster.SelectedIndex = 0;
            this.tabMaster.Size = new System.Drawing.Size(391, 501);
            this.tabMaster.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.tabMaster.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.tabMaster.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabMaster.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.tabMaster.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tabMaster.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.tabMaster.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.tabMaster.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabMaster.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.tabMaster.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.tabMaster.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.tabMaster.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.tabMaster.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabMaster.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.tabMaster.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(189)))), ((int)(((byte)(235)))));
            this.tabMaster.TabButtonSize = new System.Drawing.Size(70, 60);
            this.tabMaster.TabIndex = 1;
            this.tabMaster.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.tabMaster.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            // 
            // tabGuard
            // 
            this.tabGuard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.tabGuard.Controls.Add(this.pnl4);
            this.tabGuard.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabGuard.ImageIndex = 0;
            this.tabGuard.Location = new System.Drawing.Point(4, 64);
            this.tabGuard.Name = "tabGuard";
            this.tabGuard.Padding = new System.Windows.Forms.Padding(3);
            this.tabGuard.Size = new System.Drawing.Size(383, 433);
            this.tabGuard.TabIndex = 0;
            // 
            // pnl4
            // 
            this.pnl4.BackColor = System.Drawing.Color.Transparent;
            this.pnl4.Controls.Add(this.cbRight);
            this.pnl4.Controls.Add(this.cbLeft);
            this.pnl4.Controls.Add(this.gaugeRight);
            this.pnl4.Controls.Add(this.lbRemovedCpsRight);
            this.pnl4.Controls.Add(this.lbRemovedCpsLeft);
            this.pnl4.Controls.Add(this.lbLiveCPS);
            this.pnl4.Controls.Add(this.gaugeLeft);
            this.pnl4.Controls.Add(this.btnGuard);
            this.pnl4.Controls.Add(this.pnlUpdate);
            this.pnl4.Controls.Add(this.lbDebounceMS);
            this.pnl4.Controls.Add(this.lbCPSceiling);
            this.pnl4.Controls.Add(this.lbDT);
            this.pnl4.Controls.Add(this.tbDebouncetime);
            this.pnl4.Controls.Add(this.lbMCC);
            this.pnl4.Controls.Add(this.tbCeiling);
            this.pnl4.Controls.Add(this.lbCPSG);
            this.pnl4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.pnl4.Font = new System.Drawing.Font("Nirmala Text", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnl4.Location = new System.Drawing.Point(3, 6);
            this.pnl4.Name = "pnl4";
            this.pnl4.Radius = 10;
            this.pnl4.ShadowColor = System.Drawing.Color.Black;
            this.pnl4.ShadowShift = 8;
            this.pnl4.Size = new System.Drawing.Size(377, 424);
            this.pnl4.TabIndex = 31;
            // 
            // gaugeRight
            // 
            this.gaugeRight.ArrowColor = System.Drawing.SystemColors.ControlLight;
            this.gaugeRight.BackColor = System.Drawing.Color.Transparent;
            this.gaugeRight.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.gaugeRight.Font = new System.Drawing.Font("Verdana", 8.2F);
            this.gaugeRight.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.gaugeRight.Location = new System.Drawing.Point(220, 44);
            this.gaugeRight.MinimumSize = new System.Drawing.Size(30, 30);
            this.gaugeRight.Name = "gaugeRight";
            this.gaugeRight.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(69)))), ((int)(((byte)(72)))));
            this.gaugeRight.ProgressThickness = 10;
            this.gaugeRight.ShowPercentage = false;
            this.gaugeRight.Size = new System.Drawing.Size(130, 130);
            this.gaugeRight.TabIndex = 45;
            this.gaugeRight.UseTransparentBackground = true;
            // 
            // lbRemovedCpsRight
            // 
            this.lbRemovedCpsRight.BackColor = System.Drawing.Color.Transparent;
            this.lbRemovedCpsRight.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRemovedCpsRight.ForeColor = System.Drawing.Color.IndianRed;
            this.lbRemovedCpsRight.Location = new System.Drawing.Point(220, 18);
            this.lbRemovedCpsRight.Name = "lbRemovedCpsRight";
            this.lbRemovedCpsRight.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbRemovedCpsRight.Size = new System.Drawing.Size(130, 20);
            this.lbRemovedCpsRight.TabIndex = 44;
            this.lbRemovedCpsRight.Text = "-";
            this.lbRemovedCpsRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbRemovedCpsLeft
            // 
            this.lbRemovedCpsLeft.BackColor = System.Drawing.Color.Transparent;
            this.lbRemovedCpsLeft.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRemovedCpsLeft.ForeColor = System.Drawing.Color.IndianRed;
            this.lbRemovedCpsLeft.Location = new System.Drawing.Point(25, 18);
            this.lbRemovedCpsLeft.Name = "lbRemovedCpsLeft";
            this.lbRemovedCpsLeft.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbRemovedCpsLeft.Size = new System.Drawing.Size(130, 20);
            this.lbRemovedCpsLeft.TabIndex = 41;
            this.lbRemovedCpsLeft.Text = "-";
            this.lbRemovedCpsLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gaugeLeft
            // 
            this.gaugeLeft.ArrowColor = System.Drawing.SystemColors.ControlLight;
            this.gaugeLeft.BackColor = System.Drawing.Color.Transparent;
            this.gaugeLeft.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.gaugeLeft.Font = new System.Drawing.Font("Verdana", 8.2F);
            this.gaugeLeft.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.gaugeLeft.Location = new System.Drawing.Point(25, 44);
            this.gaugeLeft.MinimumSize = new System.Drawing.Size(30, 30);
            this.gaugeLeft.Name = "gaugeLeft";
            this.gaugeLeft.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(69)))), ((int)(((byte)(72)))));
            this.gaugeLeft.ProgressThickness = 10;
            this.gaugeLeft.ShowPercentage = false;
            this.gaugeLeft.Size = new System.Drawing.Size(130, 130);
            this.gaugeLeft.TabIndex = 38;
            this.gaugeLeft.UseTransparentBackground = true;
            // 
            // pnlUpdate
            // 
            this.pnlUpdate.Animated = true;
            this.pnlUpdate.BorderRadius = 8;
            this.pnlUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlUpdate.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.pnlUpdate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.pnlUpdate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.pnlUpdate.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.pnlUpdate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.pnlUpdate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(154)))), ((int)(((byte)(215)))));
            this.pnlUpdate.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(189)))), ((int)(((byte)(235)))));
            this.pnlUpdate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlUpdate.ForeColor = System.Drawing.Color.White;
            this.pnlUpdate.Image = ((System.Drawing.Image)(resources.GetObject("pnlUpdate.Image")));
            this.pnlUpdate.ImageSize = new System.Drawing.Size(13, 13);
            this.pnlUpdate.Location = new System.Drawing.Point(245, 365);
            this.pnlUpdate.Name = "pnlUpdate";
            this.pnlUpdate.Size = new System.Drawing.Size(105, 24);
            this.pnlUpdate.TabIndex = 18;
            this.pnlUpdate.Text = "Update now";
            this.pnlUpdate.TextOffset = new System.Drawing.Point(1, 0);
            this.pnlUpdate.Visible = false;
            this.pnlUpdate.Click += new System.EventHandler(this.pnlUpdate_Click);
            // 
            // lbDebounceMS
            // 
            this.lbDebounceMS.BackColor = System.Drawing.Color.Transparent;
            this.lbDebounceMS.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDebounceMS.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbDebounceMS.Location = new System.Drawing.Point(267, 262);
            this.lbDebounceMS.Name = "lbDebounceMS";
            this.lbDebounceMS.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbDebounceMS.Size = new System.Drawing.Size(81, 23);
            this.lbDebounceMS.TabIndex = 14;
            this.lbDebounceMS.Text = "10 ms";
            this.lbDebounceMS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbCPSceiling
            // 
            this.lbCPSceiling.BackColor = System.Drawing.Color.Transparent;
            this.lbCPSceiling.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCPSceiling.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbCPSceiling.Location = new System.Drawing.Point(267, 204);
            this.lbCPSceiling.Name = "lbCPSceiling";
            this.lbCPSceiling.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbCPSceiling.Size = new System.Drawing.Size(81, 23);
            this.lbCPSceiling.TabIndex = 13;
            this.lbCPSceiling.Text = "18 cps";
            this.lbCPSceiling.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbDT
            // 
            this.lbDT.BackColor = System.Drawing.Color.Transparent;
            this.lbDT.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDT.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbDT.Location = new System.Drawing.Point(21, 262);
            this.lbDT.Name = "lbDT";
            this.lbDT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbDT.Size = new System.Drawing.Size(137, 23);
            this.lbDT.TabIndex = 12;
            this.lbDT.Text = "Debounce Time:";
            this.lbDT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMCC
            // 
            this.lbMCC.BackColor = System.Drawing.Color.Transparent;
            this.lbMCC.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMCC.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbMCC.Location = new System.Drawing.Point(21, 204);
            this.lbMCC.Name = "lbMCC";
            this.lbMCC.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbMCC.Size = new System.Drawing.Size(137, 23);
            this.lbMCC.TabIndex = 10;
            this.lbMCC.Text = "Max CPS Ceiling:";
            this.lbMCC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabModules
            // 
            this.tabModules.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.tabModules.Controls.Add(this.pnl3);
            this.tabModules.ImageIndex = 3;
            this.tabModules.Location = new System.Drawing.Point(4, 64);
            this.tabModules.Name = "tabModules";
            this.tabModules.Padding = new System.Windows.Forms.Padding(3);
            this.tabModules.Size = new System.Drawing.Size(383, 433);
            this.tabModules.TabIndex = 3;
            // 
            // pnl3
            // 
            this.pnl3.BackColor = System.Drawing.Color.Transparent;
            this.pnl3.Controls.Add(this.rbModePulse);
            this.pnl3.Controls.Add(this.lbCB);
            this.pnl3.Controls.Add(this.lbToleranceValue);
            this.pnl3.Controls.Add(this.lbSCT);
            this.pnl3.Controls.Add(this.tbTolerance);
            this.pnl3.Controls.Add(this.rbModeTolerant);
            this.pnl3.Controls.Add(this.rbModeCutoff);
            this.pnl3.Controls.Add(this.lbCP);
            this.pnl3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.pnl3.Font = new System.Drawing.Font("Nirmala Text", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnl3.Location = new System.Drawing.Point(3, 6);
            this.pnl3.Name = "pnl3";
            this.pnl3.Radius = 10;
            this.pnl3.ShadowColor = System.Drawing.Color.Black;
            this.pnl3.ShadowShift = 8;
            this.pnl3.Size = new System.Drawing.Size(377, 424);
            this.pnl3.TabIndex = 32;
            // 
            // lbCB
            // 
            this.lbCB.BackColor = System.Drawing.Color.Transparent;
            this.lbCB.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCB.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lbCB.Location = new System.Drawing.Point(22, 47);
            this.lbCB.Name = "lbCB";
            this.lbCB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbCB.Size = new System.Drawing.Size(182, 23);
            this.lbCB.TabIndex = 52;
            this.lbCB.Text = "CEILING BEHAVIOR";
            this.lbCB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbToleranceValue
            // 
            this.lbToleranceValue.BackColor = System.Drawing.Color.Transparent;
            this.lbToleranceValue.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbToleranceValue.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbToleranceValue.Location = new System.Drawing.Point(297, 110);
            this.lbToleranceValue.Name = "lbToleranceValue";
            this.lbToleranceValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbToleranceValue.Size = new System.Drawing.Size(58, 23);
            this.lbToleranceValue.TabIndex = 33;
            this.lbToleranceValue.Text = "+ 1 cps";
            this.lbToleranceValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbSCT
            // 
            this.lbSCT.BackColor = System.Drawing.Color.Transparent;
            this.lbSCT.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSCT.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbSCT.Location = new System.Drawing.Point(22, 110);
            this.lbSCT.Name = "lbSCT";
            this.lbSCT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbSCT.Size = new System.Drawing.Size(121, 23);
            this.lbSCT.TabIndex = 50;
            this.lbSCT.Text = "Click Cut Tolerance:";
            this.lbSCT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbCP
            // 
            this.lbCP.BackColor = System.Drawing.Color.Transparent;
            this.lbCP.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCP.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbCP.Location = new System.Drawing.Point(0, 14);
            this.lbCP.Name = "lbCP";
            this.lbCP.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbCP.Size = new System.Drawing.Size(377, 24);
            this.lbCP.TabIndex = 6;
            this.lbCP.Text = "Guard Preferences";
            this.lbCP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ImageList1
            // 
            this.ImageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList1.ImageStream")));
            this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList1.Images.SetKeyName(0, "cursor-finger-click.png");
            this.ImageList1.Images.SetKeyName(1, "settings-sliders.png");
            this.ImageList1.Images.SetKeyName(2, "log-file.png");
            this.ImageList1.Images.SetKeyName(3, "sparkles(3).png");
            // 
            // TimerRealCPS
            // 
            this.TimerRealCPS.Enabled = true;
            this.TimerRealCPS.Tick += new System.EventHandler(this.TimerRealCPS_Tick);
            // 
            // TimerSmoothUI
            // 
            this.TimerSmoothUI.Enabled = true;
            this.TimerSmoothUI.Interval = 16;
            this.TimerSmoothUI.Tick += new System.EventHandler(this.TimerSmoothUI_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.ClientSize = new System.Drawing.Size(391, 501);
            this.Controls.Add(this.tabMaster);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CPS Guard - BLSquad";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabSet.ResumeLayout(false);
            this.tabLogs.ResumeLayout(false);
            this.tabMaster.ResumeLayout(false);
            this.tabGuard.ResumeLayout(false);
            this.pnl4.ResumeLayout(false);
            this.tabModules.ResumeLayout(false);
            this.pnl3.ResumeLayout(false);
            this.pnl3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Timer TimerAntiFreeze;
        internal Guna.UI2.WinForms.Guna2HtmlToolTip Guna2HtmlToolTip1;
        internal Guna.UI2.WinForms.Guna2ToggleSwitch cbCheckUpdates;
        internal Guna.UI2.WinForms.Guna2ToggleSwitch cbTray;
        internal Guna.UI2.WinForms.Guna2ToggleSwitch cbStartHidden;
        internal Guna.UI2.WinForms.Guna2ToggleSwitch cbRunStartup;
        internal Guna.UI2.WinForms.Guna2TrackBar tbLimit;
        internal Guna.UI2.WinForms.Guna2ToggleSwitch cbAlert;
        internal Guna.UI2.WinForms.Guna2ToggleSwitch cbDisableApp;
        internal Guna.UI2.WinForms.Guna2GradientButton btnGuard;
        internal Guna.UI2.WinForms.Guna2TrackBar tbDebouncetime;
        internal Guna.UI2.WinForms.Guna2TrackBar tbCeiling;
        internal System.Windows.Forms.NotifyIcon TrayIcon;
        internal Guna.UI2.WinForms.Guna2HtmlLabel lbAlertWarning;
        internal System.Windows.Forms.Label lbCU;
        internal Guna.UI2.WinForms.Guna2GradientButton btnYoutube;
        internal System.Windows.Forms.TabPage tabSet;
        internal Guna.UI2.WinForms.Guna2GradientButton btnTiktok;
        internal Guna.UI2.WinForms.Guna2GradientButton btnDiscord;
        internal Guna.UI2.WinForms.Guna2Separator sep1;
        internal System.Windows.Forms.Label lbCred;
        internal System.Windows.Forms.Label lbCPSLimit;
        internal System.Windows.Forms.Label lbAB;
        internal System.Windows.Forms.Label lbMTT;
        internal System.Windows.Forms.Label lbSH;
        internal System.Windows.Forms.Label lbRAS;
        internal System.Windows.Forms.Label lbCPST;
        internal System.Windows.Forms.Label lbCPSL;
        internal System.Windows.Forms.Label lbAOHCPS;
        internal System.Windows.Forms.Label lnDCOA;
        internal System.Windows.Forms.Label lbSettings;
        internal System.Windows.Forms.Label lbCL;
        internal Guna.UI2.WinForms.Guna2TextBox tbLogs;
        internal System.Windows.Forms.TabPage tabLogs;
        internal System.Windows.Forms.Label lbCPSG;
        internal Guna.UI2.WinForms.Guna2TabControl tabMaster;
        internal System.Windows.Forms.TabPage tabGuard;
        internal Guna.UI2.WinForms.Guna2ShadowPanel pnl4;
        internal Guna.UI2.WinForms.Guna2GradientButton pnlUpdate;
        internal System.Windows.Forms.Label lbDebounceMS;
        internal System.Windows.Forms.Label lbCPSceiling;
        internal System.Windows.Forms.Label lbDT;
        internal System.Windows.Forms.Label lbMCC;
        internal System.Windows.Forms.ImageList ImageList1;
        internal System.Windows.Forms.Timer TimerRealCPS;
        internal System.Windows.Forms.Timer TimerSmoothUI;
        private Guna.UI2.WinForms.Guna2RadialGauge gaugeLeft;
        private Guna.UI2.WinForms.Guna2RadialGauge gaugeRight;
        internal System.Windows.Forms.Label lbRemovedCpsRight;
        internal System.Windows.Forms.Label lbRemovedCpsLeft;
        internal System.Windows.Forms.Label lbLiveCPS;
        internal System.Windows.Forms.Label lbGks;
        internal Guna.UI2.WinForms.Guna2ToggleSwitch cbEKeybind;
        internal Guna.UI2.WinForms.Guna2GradientButton btnKeybind;
        internal Guna.UI2.WinForms.Guna2ToggleSwitch cbLeft;
        internal Guna.UI2.WinForms.Guna2ToggleSwitch cbRight;
        private Guna.UI2.WinForms.Guna2CheckBox cbSaveLogs;
        internal Guna.UI2.WinForms.Guna2GradientButton btnOpenLogs;
        private System.Windows.Forms.TabPage tabModules;
        internal Guna.UI2.WinForms.Guna2ShadowPanel pnl3;
        private Guna.UI2.WinForms.Guna2RadioButton rbModeTolerant;
        private Guna.UI2.WinForms.Guna2RadioButton rbModeCutoff;
        internal Guna.UI2.WinForms.Guna2TrackBar tbTolerance;
        internal System.Windows.Forms.Label lbCP;
        internal System.Windows.Forms.Label lbSCT;
        internal System.Windows.Forms.Label lbToleranceValue;
        internal System.Windows.Forms.Label lbCB;
        private Guna.UI2.WinForms.Guna2RadioButton rbModePulse;
    }
}

