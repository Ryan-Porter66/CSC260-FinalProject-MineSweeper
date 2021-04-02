using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Difficulty
{
    class Expert : IDifficulty
    {
        public int Height
        {
            get
            {
                return 16;
            }
        }
        public int Width
        {
            get
            {
                return 30;
            }
        }
        public int NumMines
        {
            get
            {
                return 99;
            }
        }
    }
}
