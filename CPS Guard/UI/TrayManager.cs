using System;
using System.Windows.Forms;

namespace CPS_Guard
{
    public static class TrayManager
    {
        private static NotifyIcon _trayIcon;
        private static Form _mainForm;
        private static Action _onExitAction;

        public static void Initialize(NotifyIcon trayIcon, Form mainForm, Action onExitAction)
        {
            _trayIcon = trayIcon;
            _mainForm = mainForm;
            _onExitAction = onExitAction;

            ContextMenuStrip ctxMenu = new ContextMenuStrip();
            ctxMenu.Items.Add("Show", null, (s, ev) => RestoreApp());
            ctxMenu.Items.Add("Exit", null, (s, ev) => _onExitAction?.Invoke());

            _trayIcon.ContextMenuStrip = ctxMenu;
            _trayIcon.Text = "CPS Guard";
            _trayIcon.Visible = true;
            _trayIcon.MouseDoubleClick += (s, e) => RestoreApp();
        }

        public static void ShowNotification(string title, string message, ToolTipIcon icon = ToolTipIcon.Info, int timeout = 2000)
        {
            _trayIcon.ShowBalloonTip(timeout, title, message, icon);
        }

        public static void MinimizeToTray(string message)
        {
            _mainForm.Hide();
            _mainForm.ShowInTaskbar = false;
            ShowNotification("CPS Guard", message, ToolTipIcon.Info, 1000);
            AppLogger.Log("CPS Guard has been Minimized to tray.");
        }

        public static void RestoreApp()
        {
            if (_mainForm != null && !_mainForm.IsDisposed)
            {
                _mainForm.Show();
                _mainForm.WindowState = FormWindowState.Normal;
                _mainForm.ShowInTaskbar = true;
            }
        }
    }
}