using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CPS_Guard
{
    public static class MouseHookManager
    {
        private static IntPtr _mouseHookID = IntPtr.Zero;
        private static NativeMethods.LowLevelMouseProc _mouseProc;
        public static bool LimitLeftClick { get; set; } = true;
        public static bool LimitRightClick { get; set; } = false;
        public static bool KeybindActivationEnabled { get; set; } = false;
        public static bool IsCursorOverApp { get; set; } = false;

        public static void StartHook()
        {
            _mouseProc = HookCallback;
            _mouseHookID = NativeMethods.SetWindowsHookEx(
                NativeMethods.WH_MOUSE_LL,
                _mouseProc,
                NativeMethods.GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName),
                0);
        }

        public static void StopHook()
        {
            if (_mouseHookID != IntPtr.Zero)
            {
                NativeMethods.UnhookWindowsHookEx(_mouseHookID);
                _mouseHookID = IntPtr.Zero;
            }
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)NativeMethods.WM_MOUSEMOVE)
                return NativeMethods.CallNextHookEx(_mouseHookID, nCode, wParam, lParam);

            bool isLeftClick = (wParam == (IntPtr)NativeMethods.WM_LBUTTONDOWN);
            bool isRightClick = (wParam == (IntPtr)NativeMethods.WM_RBUTTONDOWN);
            bool isMiddleClick = (wParam == (IntPtr)NativeMethods.WM_MBUTTONDOWN);

            if (KeybindManager.IsBinding)
            {
                if (isMiddleClick)
                {
                    KeybindManager.SetKeybind(Keys.MButton);
                    AppLogger.Log($"Keybind: New key set to [{Keys.MButton}]");
                    return (IntPtr)1;
                }
                if (isLeftClick || isRightClick)
                    return NativeMethods.CallNextHookEx(_mouseHookID, nCode, wParam, lParam);
            }

            if (isMiddleClick)
            {
                KeybindManager.TryToggleWithMiddleClick(KeybindActivationEnabled, Form1.IsGuardActive);
            }

            if (nCode >= 0 && (isLeftClick || isRightClick))
            {
                NativeMethods.MSLLHOOKSTRUCT hookStruct = (NativeMethods.MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(NativeMethods.MSLLHOOKSTRUCT));

                if ((hookStruct.flags & 0x01) == 0x01)
                    return NativeMethods.CallNextHookEx(_mouseHookID, nCode, wParam, lParam);

                if (Form1.IsAppDisabledWhenCursorInside && IsCursorOverApp)
                    return NativeMethods.CallNextHookEx(_mouseHookID, nCode, wParam, lParam);

                if (isLeftClick && !LimitLeftClick) return NativeMethods.CallNextHookEx(_mouseHookID, nCode, wParam, lParam);
                if (isRightClick && !LimitRightClick) return NativeMethods.CallNextHookEx(_mouseHookID, nCode, wParam, lParam);

                long nowTicks = CPSEngine.GlobalWatch.ElapsedMilliseconds;

                CPSEngine.AddRawClick(isLeftClick, nowTicks);

                if (!Form1.IsGuardActive)
                {
                    CPSEngine.AddAcceptedClick(isLeftClick, nowTicks);
                    return NativeMethods.CallNextHookEx(_mouseHookID, nCode, wParam, lParam);
                }

                bool clickAllowed = CPSEngine.EvaluateClick(isLeftClick, nowTicks, Form1.CurrentLimitValue, Form1.CurrentDebounceValue, Form1.DetectionMode);

                if (!clickAllowed) return (IntPtr)1;

                CPSEngine.AddAcceptedClick(isLeftClick, nowTicks);
            }

            return NativeMethods.CallNextHookEx(_mouseHookID, nCode, wParam, lParam);
        }
    }
}