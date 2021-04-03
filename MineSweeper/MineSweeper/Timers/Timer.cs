using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
