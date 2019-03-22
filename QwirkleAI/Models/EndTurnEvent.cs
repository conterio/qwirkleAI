using System.Collections.Generic;

namespace QwirkleAI.Models
{
    public class EndTurnEvent
    {
        public List<Tile> NewTiles { get; set; }
    }
}