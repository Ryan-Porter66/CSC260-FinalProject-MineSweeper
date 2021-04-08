namespace MineSweeper.Difficulty
{
	public interface IDifficulty
	{
		int Width
		{
			get;
		}

		int Height
		{
			get;
		}

		int NumMines
		{
			get;
		}
	}
}
