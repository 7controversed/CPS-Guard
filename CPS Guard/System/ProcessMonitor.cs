using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CPS_Guard
{
    public static class ProcessMonitor
    {
        private static int _myProcessId;
        private static int _lastAdminWarningProcId = -1;
        private static Timer _monitorTimer;
        public static event Action<string> OnAdminProcessDetected;
        public static event Action OnAdminProcessLeft;

        public static void Initialize()
        {
            _myProcessId = Process.GetCurrentProcess().Id;

            _monitorTimer = new Timer();
            _monitorTimer.Interval = 500;
            _monitorTimer.Tick += MonitorTimer_Tick;
        }

        public static void Start()
        {
            _monitorTimer?.Start();
        }

        public static void Stop()
        {
            _monitorTimer?.Stop();
        }

        private static void MonitorTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                NativeMethods.GetWindowThreadProcessId(NativeMethods.WindowFromPoint(Cursor.Position), out int procId);
                MouseHookManager.IsCursorOverApp = Form1.IsAppDisabledWhenCursorInside && (procId == _myProcessId);

                if (procId != 0 && procId != _myProcessId)
                {
                    if (procId != _lastAdminWarningProcId)
                    {
                        _lastAdminWarningProcId = procId;
                        bool isAdmin = IsProcessAdminComparedToMe(procId);

                        if (isAdmin)
                        {
                            string procName = "Unknown";
                            try { procName = Process.GetProcessById(procId).ProcessName; } catch { }

                            OnAdminProcessDetected?.Invoke(procName);
                            AppLogger.Log($"Warning: Admin rights required for this window ({procName})");
                        }
                        else
                        {
                            OnAdminProcessLeft?.Invoke();
                        }
                    }
                }
                else if (procId == 0 || procId == _myProcessId)
                {

                }
            }
            catch
            {
                MouseHookManager.IsCursorOverApp = false;
            }
        }

        private static bool IsProcessAdminComparedToMe(int targetProcId)
        {
            IntPtr hProcess = NativeMethods.OpenProcess(NativeMethods.PROCESS_QUERY_INFORMATION, false, targetProcId);
            if (hProcess != IntPtr.Zero)
            {
                NativeMethods.CloseHandle(hProcess);
                return false;
            }
            else
            {
                int error = Marshal.GetLastWin32Error();
                if (error == 5) return true;
            }
            return false;
        }
    }
}