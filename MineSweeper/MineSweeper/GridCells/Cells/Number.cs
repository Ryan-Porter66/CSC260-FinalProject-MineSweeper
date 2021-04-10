using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

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
		internal void CalculateMines()
        {
            this.NumMines = GetMineNeighbors();
        }
        private void DisplayNeighbors()
		{
            //displays all neighbors of a cell with no mines around it
            if (this.NumMines == 0)
            {
                foreach (Cell cell in GetNeighbors())
                {
                    cell.RevealClick();
                }
            }
        }
        private List<Cell> GetNeighbors()
        {
            //gets the cell list from around this cell
            var list = from Cell cell in this.Owner.GridOfCells
                       where (Math.Abs(cell.LocationX - this.LocationX) < 2 && Math.Abs(cell.LocationY - this.LocationY) < 2 && cell.Uncovered == false && cell.Flagged == false)
                       select cell;
            return list.ToList();
        }
        private int GetMineNeighbors()
		{
            //returns number of mines around this cell
            var list = from Cell cell in this.Owner.GridOfCells
                       where (Math.Abs(cell.LocationX - this.LocationX) < 2 && Math.Abs(cell.LocationY - this.LocationY) < 2 && cell is Mine)
                       select cell;
            return list.Count();
        }

		public override void RevealClick()
		{
            if (this.NumMines > 0)
            {
                this.Text = this.NumMines.ToString();
            }
            else
            {
                this.Uncovered = true;
                this.DisplayNeighbors();
            }

            this.BackColor = Color.LightGray;
            this.Uncovered = true;
        }
        #endregion
    }
}
