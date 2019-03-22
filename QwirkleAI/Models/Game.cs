using System;
using System.Collections.Generic;

namespace QwirkleAI.Models
{
    public class Game
    {
        public Guid GameId { get; set; }
        public List<Player> Players { get; set; }
        public GameSettings GameSettings { get; set; }
        public string CurrentTurnPlayerId { get; set; }
    }
}