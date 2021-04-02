using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.GridCells.Cells
{
	public abstract class Cell
	{
        #region Fields
        bool _flagged;
		int _locationX;
		int _locationY;
		Grid _owner;
		bool _uncovered;
		public const int xDefaultLoc = 15, yDefaultLoc = 50, spaceBetweenButtons = 30;
        #endregion
        #region Properties
        public bool Flagged
		{
			get
			{
				return this._flagged;
			}
			set
			{
				this._flagged = value;
			}
		}

		public int LocationX
		{
			get
			{
				return this._locationX;
			}
			set
			{
				this._locationX = value;
			}
		}

		public int LocationY
		{
			get
			{
				return this._locationY;
			}
			set
			{
				this._locationY = value;
			}
		}

		public Grid Owner
		{
			get
			{
				return this._owner;
			}
			set
			{
				this._owner = value;
			}
		}

		public bool Uncovered
		{
			get
			{
				return this._uncovered;
			}
			set
			{
				this._uncovered = value;
			}
		}
        #endregion
        #region Constructor
        public Cell(int x, int y, Grid owner)
		{
			throw new NotImplementedException();
		}
        #endregion
        #region Methods
        public void Click()
		{
			throw new NotImplementedException();
		}

		public void FlagClick()
		{
			throw new NotImplementedException();
		}

		public abstract void RevealClick();
        #endregion
    }
}
