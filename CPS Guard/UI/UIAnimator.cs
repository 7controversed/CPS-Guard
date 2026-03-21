using System;

namespace CPS_Guard
{
    public static class UIAnimator
    {
        private static double _currentDisplayedLeft = 0;
        private static double _currentDisplayedRight = 0;
        private static int _targetCPSValueLeft = 0;
        private static int _targetCPSValueRight = 0;
        private const double SPEED_FACTOR = 0.45;

        public static void SetTargets(int targetLeft, int targetRight)
        {
            _targetCPSValueLeft = targetLeft;
            _targetCPSValueRight = targetRight;
        }

        public static (int leftPercent, int rightPercent) CalculateNextFrame(int currentLimit)
        {

            double maxVisualCPS = Math.Max(8.0, (double)currentLimit);
            _currentDisplayedLeft += (_targetCPSValueLeft - _currentDisplayedLeft) * SPEED_FACTOR;
            int percentLeft = (int)((_currentDisplayedLeft / maxVisualCPS) * 100);

            _currentDisplayedRight += (_targetCPSValueRight - _currentDisplayedRight) * SPEED_FACTOR;
            int percentRight = (int)((_currentDisplayedRight / maxVisualCPS) * 100);

            percentLeft = Math.Max(0, Math.Min(100, percentLeft));
            percentRight = Math.Max(0, Math.Min(100, percentRight));

            return (percentLeft, percentRight);
        }
    }
}