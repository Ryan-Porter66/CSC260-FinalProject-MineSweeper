using System.Windows.Forms;
using System.Drawing;

namespace MineSweeper.GridCells.Cells
{
	public abstract class Cell : Button
	{
        #region Fields
        bool _flagged;
		int _locationX;
		int _locationY;
		Grid _owner;
		bool _uncovered;
		public const int buttonSize = 30;
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
			this._locationX = x;
			this._locationY = y;
			this._owner = owner;
			this._flagged = this._uncovered = false;
			//https://naikrahul.wordpress.com/tricks-tips/c-how-to-add-click-event-for-dynamically-created-buttons/
			this.Size = new Size(buttonSize, buttonSize);
			this.MouseDown += new MouseEventHandler(this.Owner.Board.ClickCell);
			this.Owner.Board.Controls.Add(this);
			this.FlatStyle = FlatStyle.Flat;
			this.BackColor = Color.White;
			//https://stackoverflow.com/questions/14354922/remove-blue-outlining-of-buttons
			this.SetStyle(ControlStyles.Selectable, false);
		}
        #endregion
        #region Methods
		internal void FlagClick()
		{
			//https://www.c-sharpcorner.com/uploadfile/mahesh/display-an-image-as-button-background-in-C-Sharp/
			// got image from https://commons.wikimedia.org/wiki/File:Minesweeper_flag.svg
			if (!(this.Flagged) && this.Owner.Board.NumFlags > 0)
			{
				this.Image = (Image)(new Bitmap(Properties.Resources.FlagIcon, new Size(32, 32)));
				this.Owner.Board.NumFlags--;
				this.Owner.Board.FlagsBox_TextChanged(null, null);
				this.Flagged = !(this.Flagged);
			}
			else if (this.Flagged)
			{
				this.Image = null;
				this.Owner.Board.NumFlags++;
				this.Owner.Board.FlagsBox_TextChanged(null, null);
				this.Flagged = !(this.Flagged);
			}
		}

		public abstract void RevealClick();
        #endregion
    }
}
