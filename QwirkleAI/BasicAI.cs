using QwirkleAI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QwirkleAI
{
    public class BasicAI 
    {
		public string Id { get; set; }
		private AIHub AIHub { get; set; }

        //Delegates
        public Action<TurnEvent> takeTurnDelegate = new Action<TurnEvent>(TakeTurn);


		public BasicAI()
        {
			AIHub = new AIHub(this);
			Id = AIHub.GetId();
        }

        public void JoinGame(Guid gameId)
        {
			AIHub.JoinGame(gameId);
        }

		private static void TakeTurn(TurnEvent turnEvent)
		{

		}
    }
}
