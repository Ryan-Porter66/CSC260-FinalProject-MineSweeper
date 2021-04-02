using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Difficulty
{
    class Easy : IDifficulty
    {
        //values gotten from https://minesweeperonline.com/
        public int Height
        {
            get
            {
                return 9;
            }
        }
        public int Width
        {
            get
            {
                return 9;
            }
        }
        public int NumMines
        {
            get
            {
                return 10;
            }
        }
    }
}
