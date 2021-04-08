namespace MineSweeper.Timers
{
    class Timer
    {
        #region Methods
        public static int IncreaseTimer(int elapsed)
        {
            if (elapsed < 999)
            {
                elapsed++;
            }
            return elapsed;
        }
        #endregion
    }
}
