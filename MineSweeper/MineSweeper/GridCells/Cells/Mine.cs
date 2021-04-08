using System.Drawing;

namespace MineSweeper.GridCells.Cells
{
    class Mine : Cell
    {
        #region Constructor
        public Mine(int x, int y, Grid owner) : base(x, y, owner)
		{
		}
        #endregion
        #region Methods
        public override void RevealClick()
		{
            this.Image = (Image)(new Bitmap(Properties.Resources.FlagIcon, new Size(32, 32)));
            this.Owner.GameLost();
        }
        #endregion
    }
}
