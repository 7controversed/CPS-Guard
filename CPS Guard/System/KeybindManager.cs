using System;
using System.Windows.Forms;

namespace CPS_Guard
{
    public static class KeybindManager
    {
        public static Keys CurrentKeybind { get; set; } = Keys.None;
        public static bool IsBinding { get; private set; } = false;
        private static Timer _timerBinding;
        private static int _bindingCountdown = 5;
        private static DateTime _lastKeybindToggle = DateTime.MinValue;
        private static bool _isKeyAlreadyDown = false;
        public static event Action<int> OnBindingTick;
        public static event Action OnBindingStopped;
        public static event Action OnTriggerGuard;

        public static void Initialize()
        {
            _timerBinding = new Timer();
            _timerBinding.Interval = 1000;
            _timerBinding.Tick += TimerBinding_Tick;
        }

        public static void StartBinding()
        {
            IsBinding = true;
            _bindingCountdown = 5;
            _timerBinding.Start();
            OnBindingTick?.Invoke(_bindingCountdown);
        }

        public static void StopBinding()
        {
            IsBinding = false;
            _timerBinding.Stop();
            OnBindingStopped?.Invoke();
        }

        private static void TimerBinding_Tick(object sender, EventArgs e)
        {
            _bindingCountdown--;
            if (_bindingCountdown > 0)
            {
                OnBindingTick?.Invoke(_bindingCountdown);
            }
            else
            {
                StopBinding();
                AppLogger.Log("Keybind: Time out. No key set.");
            }
        }

        public static void SetKeybind(Keys key)
        {
            CurrentKeybind = key;
            _lastKeybindToggle = DateTime.Now;
            StopBinding();
        }

        public static void ResetKeybind()
        {
            CurrentKeybind = Keys.None;
            StopBinding();
        }

        public static void CheckPeriodicState(bool isEnabled)
        {
            if (IsBinding || !isEnabled || CurrentKeybind == Keys.None) return;

            bool isDown = (NativeMethods.GetAsyncKeyState((int)CurrentKeybind) & 0x8000) != 0;
            if (isDown)
            {
                if (!_isKeyAlreadyDown)
                {
                    _isKeyAlreadyDown = true;
                    if ((DateTime.Now - _lastKeybindToggle).TotalMilliseconds >= 1000)
                    {
                        _lastKeybindToggle = DateTime.Now;
                        OnTriggerGuard?.Invoke();
                    }
                }
            }
            else
            {
                _isKeyAlreadyDown = false;
            }
        }

        public static void TryToggleWithMiddleClick(bool isEnabled, bool isGuardActive)
        {
            if (isEnabled && !isGuardActive && CurrentKeybind == Keys.MButton)
            {
                if ((DateTime.Now - _lastKeybindToggle).TotalMilliseconds >= 1000)
                {
                    _lastKeybindToggle = DateTime.Now;
                    OnTriggerGuard?.Invoke();
                }
            }
        }

        public static Keys GetActualKey(Keys baseKey)
        {
            Keys actualKey = baseKey;
            if (actualKey == Keys.ShiftKey)
            {
                if ((NativeMethods.GetAsyncKeyState((int)Keys.LShiftKey) & 0x8000) != 0) actualKey = Keys.LShiftKey;
                else if ((NativeMethods.GetAsyncKeyState((int)Keys.RShiftKey) & 0x8000) != 0) actualKey = Keys.RShiftKey;
            }
            else if (actualKey == Keys.ControlKey)
            {
                if ((NativeMethods.GetAsyncKeyState((int)Keys.LControlKey) & 0x8000) != 0) actualKey = Keys.LControlKey;
                else if ((NativeMethods.GetAsyncKeyState((int)Keys.RControlKey) & 0x8000) != 0) actualKey = Keys.RControlKey;
            }
            else if (actualKey == Keys.Menu)
            {
                if ((NativeMethods.GetAsyncKeyState((int)Keys.LMenu) & 0x8000) != 0) actualKey = Keys.LMenu;
                else if ((NativeMethods.GetAsyncKeyState((int)Keys.RMenu) & 0x8000) != 0) actualKey = Keys.RMenu;
            }
            return actualKey;
        }
    }
}