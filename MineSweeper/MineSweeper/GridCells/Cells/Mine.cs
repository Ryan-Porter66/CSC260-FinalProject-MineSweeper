using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.GridCells.Cells
{
    class Mine : Cell
    {
        #region Constructor
        public Mine(int x, int y, Grid owner) : base(x, y, owner)
		{
		}
        #endregion
        #region Methods
        public override void RevealClick()
		{
            this.Text = "M";
            this.Owner.GameLost();
        }
        #endregion
    }
}
