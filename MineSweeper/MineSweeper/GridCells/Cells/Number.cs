using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.GridCells.Cells
{
    class Number : Cell
    {
        #region Fields
        int _numMines;
        #endregion
        #region Properties
        public int NumMines
		{
			get
			{
				return this._numMines;
			}
			set
			{
				this._numMines = value;
			}
		}
        #endregion
        #region Constructor
        public Number(int x, int y, Grid owner) : base(x, y, owner)
		{
		}
        #endregion
        #region Methods
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
        #endregion
    }
}
