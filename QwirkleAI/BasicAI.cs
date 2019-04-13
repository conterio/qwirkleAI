using System;
using System.Collections.Generic;
using System.Text;

namespace QwirkleAI
{
    public class BasicAI 
    {
		public string Id { get; set; }
		private AIHub AIHub { get; set; }
		public BasicAI()
        {
			AIHub = new AIHub(this);
			Id = AIHub.GetId();
        }

        public void JoinGame(Guid gameId)
        {
			AIHub.JoinGame(gameId);
        }

		public void TakeTurn()
		{

		}
    }
}
