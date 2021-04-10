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
            //turn the cell red with the mine that was clicked
            this.BackColor = Color.Red;
            this.Owner.GameLost();
        }
        #endregion
    }
}
