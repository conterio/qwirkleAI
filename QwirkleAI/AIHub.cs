using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using QwirkleAI.Models;

namespace QwirkleAI
{
    public class AIHub : BaseHub
    {
		private BasicAI myAi;
		public AIHub(BasicAI _myAi)
        {
			myAi = _myAi;
			Initialize();
			
        }

		public string GetId()
		{
			return connection.InvokeAsync<string>("GetPlayerId").Result;
		}

		public void JoinGame(Guid gameId)
		{
			connection.InvokeAsync("JoinGame", gameId);
		}

		private void Initialize()
        {
			//TODO implement basic ai functions and call them here
			//connection.On<TurnEvent>("TurnEvent",(myAi.TakeTurn()));
			//connection.On<EndTurnEvent>("EndTurnEvent",( endTurn);
			//connection.On<StartGameEvent>("GameStartedEvent",( startGameEvent);
			//connection.On<EndGameEvent>("GameOverEvent",( endGameEvent);
			//connection.On<GameInfoEvent>("GameInfoEvent",( gameInfoEvent);
			//connection.On<PlayerJoinedEvent>("PlayerJoinedEvent",( playerJoinedEvent);
			//connection.On<PlayerRemovedEvent>("PlayerRemovedEvent",( playerRemovedEvent);

		}
    }
}
