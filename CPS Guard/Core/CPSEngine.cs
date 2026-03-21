using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CPS_Guard
{
    public static class CPSEngine
    {
        private static List<long> _clickHistoryLeft = new List<long>(100);
        private static List<long> _rawClickHistoryLeft = new List<long>(100);
        private static List<long> _clickHistoryRight = new List<long>(100);
        private static List<long> _rawClickHistoryRight = new List<long>(100);
        private static long _lastLeftClickTick = 0;
        private static long _lastRightClickTick = 0;
        private static Random _rnd = new Random();
        public static readonly Stopwatch GlobalWatch = Stopwatch.StartNew();
        private static double _pulsePhase = 0;
        private static double _currentPulseLimit = 0;
        private static double _smartTokensLeft = 0;
        private static double _smartTokensRight = 0;
        private static long _lastSmartRefillLeft = 0;
        private static long _lastSmartRefillRight = 0;

        public static void AddRawClick(bool isLeftClick, long nowTicks)
        {
            var targetRawHistory = isLeftClick ? _rawClickHistoryLeft : _rawClickHistoryRight;
            lock (targetRawHistory) { targetRawHistory.Add(nowTicks); }
        }

        public static void AddAcceptedClick(bool isLeftClick, long nowTicks)
        {
            var targetClickHistory = isLeftClick ? _clickHistoryLeft : _clickHistoryRight;
            lock (targetClickHistory) { targetClickHistory.Add(nowTicks); }
        }

        public static void ResetEngine(int currentLimit, long nowTicks)
        {
            double maxTokens = Math.Max(2.0, (double)currentLimit * 0.25);
            _smartTokensLeft = maxTokens;
            _smartTokensRight = maxTokens;
            _lastSmartRefillLeft = nowTicks;
            _lastSmartRefillRight = nowTicks;
            _pulsePhase = 0;

            _lastLeftClickTick = nowTicks;
            _lastRightClickTick = nowTicks;
        }

        public static void UpdatePulsePhase(int currentLimit)
        {

            _pulsePhase += 0.05 + (_rnd.NextDouble() * 0.07);
            if (_pulsePhase > Math.PI * 2) _pulsePhase -= Math.PI * 2;

            double variation = Math.Sin(_pulsePhase) * 1.5;
            _currentPulseLimit = currentLimit + variation;

            if (_currentPulseLimit < 2) _currentPulseLimit = 2;
        }

        public static void CleanHistoryAndGetStats(long cutoff, out int acceptedLeft, out int rawLeft, out int acceptedRight, out int rawRight)
        {
            lock (_clickHistoryLeft) { _clickHistoryLeft.RemoveAll(t => t < cutoff); acceptedLeft = _clickHistoryLeft.Count; }
            lock (_rawClickHistoryLeft) { _rawClickHistoryLeft.RemoveAll(t => t < cutoff); rawLeft = _rawClickHistoryLeft.Count; }
            lock (_clickHistoryRight) { _clickHistoryRight.RemoveAll(t => t < cutoff); acceptedRight = _clickHistoryRight.Count; }
            lock (_rawClickHistoryRight) { _rawClickHistoryRight.RemoveAll(t => t < cutoff); rawRight = _rawClickHistoryRight.Count; }
        }

        private static double GetGaussian(double mean, double stdDev)
        {
            double u1 = 1.0 - _rnd.NextDouble();
            double u2 = 1.0 - _rnd.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
            return mean + (stdDev * randStdNormal);
        }

        public static bool EvaluateClick(bool isLeftClick, long nowTicks, int currentLimit, int currentDebounce, int detectionMode)
        {
            int effectiveDebounce = (int)GetGaussian(currentDebounce, 3.0);
            if (effectiveDebounce < 5) effectiveDebounce = 5;

            long lastTime = isLeftClick ? _lastLeftClickTick : _lastRightClickTick;
            if (nowTicks - lastTime < effectiveDebounce) return false;

            bool clickAllowed = false;

            if (detectionMode == 3 || detectionMode == 2)
            {
                double bucketCapacity = (detectionMode == 2)
                    ? Math.Max(1.5, (double)currentLimit * 0.15)
                    : Math.Max(2.0, (double)currentLimit * 0.25);

                double currentTokens = isLeftClick ? _smartTokensLeft : _smartTokensRight;
                long lastRefill = isLeftClick ? _lastSmartRefillLeft : _lastSmartRefillRight;

                double deltaSeconds = (double)(nowTicks - lastRefill) / 1000.0;
                if (deltaSeconds < 0) deltaSeconds = 0;

                double effectiveLimit = (detectionMode == 3) ? (double)currentLimit : _currentPulseLimit;

                currentTokens += deltaSeconds * effectiveLimit;
                if (currentTokens > bucketCapacity) currentTokens = bucketCapacity;

                if (currentTokens >= 1.0)
                {
                    currentTokens -= 1.0;
                    clickAllowed = true;
                }
                else clickAllowed = false;

                if (isLeftClick) { _smartTokensLeft = currentTokens; _lastSmartRefillLeft = nowTicks; }
                else { _smartTokensRight = currentTokens; _lastSmartRefillRight = nowTicks; }
            }
            else
            {
                var targetHistory = isLeftClick ? _clickHistoryLeft : _clickHistoryRight;
                lock (targetHistory)
                {
                    if (targetHistory.Count < currentLimit) clickAllowed = true;
                }
            }

            if (clickAllowed)
            {
                if (isLeftClick) _lastLeftClickTick = nowTicks;
                else _lastRightClickTick = nowTicks;
            }

            return clickAllowed;
        }
    }
}