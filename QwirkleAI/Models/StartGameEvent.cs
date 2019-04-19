using System.Collections.Generic;

namespace QwirkleAI.Models
{
    public class StartGameEvent
    {
        public string CurrentPlayerId { get; set; }
        public List<string> PlayerOrder { get; set; }
		public List<Tile> StartingHand { get; set; }
	}
}