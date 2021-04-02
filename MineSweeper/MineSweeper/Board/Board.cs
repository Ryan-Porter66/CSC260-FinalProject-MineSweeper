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
        #region Fields
        private Grid _grid;
		IDifficulty _gameMode;
		private int _numFlags;
        #endregion
        #region Properties
        public Grid CellGrid
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

		public int NumFlags
		{
			get
			{
				return this._numFlags;
			}
			set
			{
				this._numFlags = value;
			}
		}
        #endregion
        #region Constructor
        public Board()
		{
			this.GameMode = new Easy();
			InitializeComponent();
		}
        #endregion
        #region Board Buttons
        private void easyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void intermediateToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void expertToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void highScoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void FlagsBox_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion
        #region Methods
        private void StartGame()
		{
			throw new NotImplementedException();
		}

		private void Click_Cell(object Sender, MouseEventArgs e)
		{
			throw new NotImplementedException();
		}
        #endregion

    }
}