using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MineSweeper.GridCells;
using MineSweeper.GridCells.Cells;
using MineSweeper.Difficulty;

namespace MineSweeper
{
    public partial class Board : Form
    {
        #region Fields
        private Grid _grid;
		IDifficulty _gameMode;
		private int _numFlags;
		public const int buttonSize = 30, xDefaultLoc = 20, yDefaultLoc = 50, spaceBetweenButtons = 30;
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
		public bool FirstClick { get; set; }
		public int TimeElapsed { get; private set; }
		#endregion
		#region Constructor
		public Board()
		{
            InitializeComponent();
			//standard difficulty is easy
			this.GameMode = new Easy();
			this.StartGame();
		}
        #endregion
        #region Board Buttons
        private void easyToolStripMenuItem_Click(object sender, EventArgs e)
        {
			this.GameMode = new Easy();
			this.timer1.Stop();
			this.StartGame();
		}
        private void intermediateToolStripMenuItem_Click(object sender, EventArgs e)
        {
			this.GameMode = new Intermediate();
			this.timer1.Stop();
			this.StartGame();
		}
        private void expertToolStripMenuItem_Click(object sender, EventArgs e)
        {
			this.GameMode = new Expert();
			this.timer1.Stop();
			this.StartGame();
		}
        private void customToolStripMenuItem_Click(object sender, EventArgs e)
        {
			this.GameMode = new Custom();
			this.timer1.Stop();
			this.StartGame();
        }
        private void highScoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
			//calls function in HighScores class
			High_Scores.HighScores.DisplayHighScores();
		}
        private void timer1_Tick(object sender, EventArgs e)
        {
			//https://docs.microsoft.com/en-us/visualstudio/ide/step-6-add-a-timer?view=vs-2019
			//max time is 999 seconds
			if (this.TimeElapsed < 999)
			{
				this.TimeElapsed = Timers.Timer.IncreaseTimer(this.TimeElapsed);
				TimerLabel.Text = "Time: " + this.TimeElapsed.ToString();
			}
			else
			{
				//if 999 seconds has passed, stop the timer
				this.timer1.Stop();
			}
		}
        internal void FlagsBox_TextChanged(object sender, EventArgs e)
        {
			//displays the number of flags left
			this.FlagsBox.Text = "Flags: " + this.NumFlags;
		}
        #endregion
        #region Methods
        internal void StartGame()
		{
			//https://www.codeproject.com/Questions/646695/how-to-reload-form-or-refresh-form-in-csharp-net
			this.Controls.Clear();
			this.InitializeComponent();
			this.CellGrid = new Grid(this, GameMode);
			this.NumFlags = this.GameMode.NumMines;
			this.TimeElapsed = 0;
			this.FlagsBox_TextChanged(null, null);
			this.FirstClick = true;
			this.CellGrid.GridSetUp();
			//https://docs.microsoft.com/en-us/dotnet/desktop/winforms/forms/how-to-position-and-resize?view=netdesktop-5.0
			Width = this.GameMode.Width * buttonSize + (int)(buttonSize * 1.50);
			Height = this.GameMode.Height * buttonSize + (int)(buttonSize * 3.5);
			this.TimerLabel.Location = new Point(this.GameMode.Width * buttonSize - 3 * buttonSize + 15, this.TimerLabel.Location.Y);
		}

		internal void ClickCell(object sender, MouseEventArgs e)
		{
			//https://stackoverflow.com/questions/9450382/visual-c-sharp-form-right-click-button
			//https://stackoverflow.com/questions/19448346/how-to-get-a-right-click-mouse-event-changing-eventargs-to-mouseeventargs-cause
			var clickedCell = from Cell item in this.CellGrid.GridOfCells
							  where item == sender
							  select item;
			foreach (Cell cell in clickedCell)
			{
				switch (e.Button)
				{
					case MouseButtons.Left:
						if (!(cell.Flagged))
						{
							//instead of moving the mine, just tell the user they clicked a mine
							//not the best way to do it, but it works
							if (FirstClick && cell is Mine)
							{
								MessageBox.Show("First click was a mine. Please select again.");
							}
							else
							{
								FirstClick = false;
								this.timer1.Start();
								cell.RevealClick();
								cell.Enabled = false;
								//check for win after each click
								this.CellGrid.CheckForWin();
							}
						}
						break;
					case MouseButtons.Right:
						if (!(cell.Uncovered))
						{
							cell.FlagClick();
						}
						break;
					default:
						break;
				}
			}
		}
		#endregion
    }
}