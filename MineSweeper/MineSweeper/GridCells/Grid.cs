using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MineSweeper.GridCells.Cells;
using MineSweeper.Difficulty;

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
        internal void CheckWin()
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
			throw new NotImplementedException();
		}

		internal void SetMines()
		{
			throw new NotImplementedException();
		}
        #endregion
    }
}
