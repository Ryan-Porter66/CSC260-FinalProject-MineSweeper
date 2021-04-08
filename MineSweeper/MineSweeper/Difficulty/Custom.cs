using System;
using System.Windows.Forms;
using System.Drawing;

namespace MineSweeper.Difficulty
{
    class Custom : IDifficulty
    {
        #region Fields
        private int _height;
        private int _width;
        private int _numMines;
        #endregion
        #region Constructor
        public Custom()
        {
            this.Height = getIntValue("Please enter the height of the board (range of 1-50).");
            this.Width = getIntValue("Please enter the width of the board (range of 8-50).");
            this.NumMines = getIntValue("Please enter the number of mines.");
        }
        #endregion
        #region Properties
        public int Height
        {
            get
            {
                return this._height;
            }
            set
            {
                if(value > 50 || value < 1)
                {
                    this._height = 25;
                }
                else
                {
                    this._height = value;
                }
            }
        }
        public int Width
        {
            get
            {
                return this._width;
            }
            set
            {
                if(value > 50 || value < 8)
                {
                    this._width = 25;
                } else
                {
                    this._width = value;
                }
            }
        }
        public int NumMines
        {
            get
            {
                return this._numMines;
            }
            set
            {
                if(value >= this._width * this._height || value < 1)
                {
                    this._numMines = this._width * this._height - 1;
                } else
                {
                    this._numMines = value;
                }
            }
        }
        #endregion
        #region Methods
        private int getIntValue(string displayString)
        {
            //https://stackoverflow.com/questions/5427020/prompt-dialog-in-windows-forms
            Form name = new Form();
            name.Size = new Size(250, 150);
            Label newHS = new Label();
            newHS.Text = displayString;
            newHS.Location = new Point(10, 10);
            newHS.Size = new Size(188, 26);
            TextBox input = new TextBox();
            input.MaxLength = 3;
            input.Size = new Size(130, 13);
            input.Location = new Point(12, 40);
            Button confirmation = new Button();
            confirmation.Text = "OK";
            confirmation.Location = new Point(10, 70);
            confirmation.Click += (sender, e) => { name.Close(); };
            confirmation.DialogResult = DialogResult.OK;
            name.Controls.Add(newHS);
            name.Controls.Add(input);
            name.Controls.Add(confirmation);
            name.AcceptButton = confirmation;

            if (name.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    int returnValue = Int32.Parse(input.Text);
                    return returnValue;
                } 
                catch
                {
                    return 25;
                }
                
            }
            else
            {
                return 25;
            }
        }
        #endregion
    }
}
