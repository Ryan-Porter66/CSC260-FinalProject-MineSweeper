using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MineSweeper.GridCells.Cells;
using MineSweeper.Difficulty;
using System.Drawing;
using System.Windows.Forms;

namespace MineSweeper.GridCells
{
    public class Grid
    {
        #region Fields
        private Board _board;
		IDifficulty _gameMode;
		Cell[,] _grid;
		public const int xDefaultLoc = 15, yDefaultLoc = 50, spaceBetweenButtons = 30;
		#endregion
		#region Properties
		public Board Board
		{
			get
			{
				return this._board;
			}
			set
			{
				this._board = value;
			}
		}

		public IDifficulty GameMode
		{
			get
			{
				return this._gameMode;
			}
			set
			{
				this._gameMode = value;
			}
		}

		public Cell[,] GridOfCells
		{
			get
			{
				return this._grid;
			}
			set
			{
				this._grid = value;
			}
		}
        #endregion
        #region Constructor
        public Grid(Board board, IDifficulty difficulty)
		{
			this.Board = board;
			this.GameMode = difficulty;
			this.GridOfCells = new Cell[GameMode.Width, GameMode.Height];
		}
        #endregion
        #region Methods
        internal void CheckForWin()
		{
			throw new NotImplementedException();
		}

		private void DisplayMines()
		{
			throw new NotImplementedException();
		}

		internal void GameLost()
		{
			throw new NotImplementedException();
		}

		internal void GameWon()
		{
			throw new NotImplementedException();
		}

		internal void GridSetUp()
		{
			this.SetMines();
			//https://naikrahul.wordpress.com/tricks-tips/c-how-to-add-click-event-for-dynamically-created-buttons/
			int xBoardLoc = xDefaultLoc, yBoardLoc = yDefaultLoc;
			for (int index1 = 0; index1 < this.GameMode.Height; index1++)
			{
				for (int index2 = 0; index2 < this.GameMode.Width; index2++)
				{
					if (!(this.GridOfCells[index2, index1] is Mine))
					{
						this.GridOfCells[index2, index1] = new Number(index2, index1, this);
						this.GridOfCells[index2, index1].Location = new Point(xBoardLoc, yBoardLoc);
					}
					xBoardLoc += spaceBetweenButtons;
				}
				xBoardLoc = xDefaultLoc;
				yBoardLoc += spaceBetweenButtons;
			}
			this.SetNumbers();
		}

		private void SetMines()
		{
			//https://docs.microsoft.com/en-us/dotnet/api/system.random?view=net-5.0
			var rand = new Random();
			int minesPlaced = 0;

			while (minesPlaced < this.GameMode.NumMines)
			{
				int x = rand.Next(0, this.GameMode.Width);
				int y = rand.Next(0, this.GameMode.Height);
				//https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/type-testing-and-cast
				if (!(this.GridOfCells[x, y] is Mine))
				{
					this.GridOfCells[x, y] = new Mine(x, y, this);
					this.GridOfCells[x, y].Location = new Point(x * 30 + 15, y * 30 + 50);
					minesPlaced++;
				}
			}
		}
		private void SetNumbers()
        {
			foreach (var cell in this.GridOfCells)
			{
				if (cell is Number)
				{
					//https://stackoverflow.com/questions/57404994/iterate-over-generic-list-with-multiple-types
					var newCell = (Number)cell;
					newCell.CalculateMines();
				}
			}
		}
        #endregion
    }
}
