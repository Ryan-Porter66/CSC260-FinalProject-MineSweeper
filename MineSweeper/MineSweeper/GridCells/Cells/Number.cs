using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.GridCells.Cells
{
    class Number : Cell
    {
		int _numMines;

		public int NumMines
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public Number(int x, int y, Grid owner)
		{
			throw new NotImplementedException();
		}

		private void DisplayNeighbors()
		{
			throw new NotImplementedException();
		}

		private int GetMineNeighbors()
		{
			throw new NotImplementedException();
		}

		public override void RevealClick()
		{
			throw new NotImplementedException();
		}

		internal void SetNumberOfMines()
		{
			throw new NotImplementedException();
		}
	}
}
