using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MineSweeper.GridCells;
using MineSweeper.GridCells.Cells;
using MineSweeper.Difficulty;
using System.Diagnostics;
using MineSweeper.Timers;

namespace MineSweeper
{
    public partial class Board : Form
    {
		private Grid _cellGrid;
		IDifficulty _gameMode;
		private int _numFlags;

		public Grid CellGrid
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

		public IDifficulty GameMode
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

		public int NumFlags
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

		public Board()
		{
			InitializeComponent();
		}

		private void StartGame()
		{
			throw new NotImplementedException();
		}

		private void Click_Cell(object Sender, MouseEventArgs e)
		{
			throw new NotImplementedException();
		}
	}
}