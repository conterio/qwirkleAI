using Models.Internal.QwirkleAI;
using QwirkleAI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QwirkleAI
{
	public class Game
	{
		public Game()
		{
			Players = new Dictionary<string, Player>();
			GameSettings = new GameSettings();
			GameBoard = new GameBoard();
			CurrentHand = new List<Tile>();
		}

		public Guid GameId { get; set; }
		public Dictionary<string, Player> Players { get; set; }
		public GameSettings GameSettings { get; set; }
		public GameBoard GameBoard { get; set; }
		public List<Tile> CurrentHand { get; set; }
	}
}


