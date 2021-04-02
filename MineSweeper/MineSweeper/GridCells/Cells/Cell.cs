using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.GridCells.Cells
{
	public abstract class Cell
	{
		bool _flagged;
		int _locationX;
		int _locationY;
		Grid _owner;
		bool _uncovered;

		public bool Flagged
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

		public int LocationX
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

		public int LocationY
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

		public Grid Owner
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

		public bool Uncovered
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

		public Cell(int x, int y, Grid owner)
		{
			throw new NotImplementedException();
		}

		public void Click()
		{
			throw new NotImplementedException();
		}

		public void FlagClick()
		{
			throw new NotImplementedException();
		}

		public abstract void RevealClick();
	}
}
