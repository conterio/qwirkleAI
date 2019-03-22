using System;

namespace QwirkleAI.Models
{
    public class PlayerJoinedEvent
    {
        public string PlayerId { get; set; }
        public string Name { get; set; }
    }
}