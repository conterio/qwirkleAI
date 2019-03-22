using System.Collections.Generic;

namespace QwirkleAI.Models
{
	public class GameInfoEvent
	{
        public List<(string PlayerId, string Name)> Players { get; set; }
        public GameSettings GameSettings { get; set; }
    }
}