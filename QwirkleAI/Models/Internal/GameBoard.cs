using QwirkleAI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Internal.QwirkleAI
{
	public class GameBoard
	{
		public GameBoard()
		{
			_tilePlacements = new List<TilePlacement>();
		}

		//This is a list of all the tiles that have been played on the board so far
		private List<TilePlacement> _tilePlacements;
	}
}
