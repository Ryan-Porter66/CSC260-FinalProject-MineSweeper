﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
