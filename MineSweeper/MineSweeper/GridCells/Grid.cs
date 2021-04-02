using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.GridCells
{
    class Grid
    {
		private Board _board;
		IDifficulty _gameMode;
		Cell[,] _grid;

		public Board board
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

		public Difficulty GameMode
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

		public Cell[,] Grid
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

		public Grid(Board board, Difficulty difficulty)
		{
			throw new NotImplementedException();
		}

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
	}
}
