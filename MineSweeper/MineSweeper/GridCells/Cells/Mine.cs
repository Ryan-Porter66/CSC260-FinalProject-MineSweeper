using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.GridCells.Cells
{
    class Mine : Cell
    {
		public Mine(int x, int y, Grid owner) : base(x, y, owner)
		{
		}

		public override void RevealClick()
		{
			throw new NotImplementedException();
		}
	}
}
