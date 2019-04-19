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
		private readonly BasicAI basicAi;
		public AIHub(BasicAI _basicAi)
		{
			basicAi = _basicAi;
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
			connection.On<TurnEvent>("TurnEvent", basicAi.TakeTurn);
			connection.On<EndTurnEvent>("EndTurnEvent", basicAi.EndTurn);
			connection.On<StartGameEvent>("GameStartedEvent", basicAi.StartGame);
			connection.On<EndGameEvent>("GameOverEvent", basicAi.EndGame);
			connection.On<GameInfoEvent>("GameInfoEvent", basicAi.GameInfo);
			connection.On<PlayerJoinedEvent>("PlayerJoinedEvent", basicAi.PlayerJoined);
			connection.On<PlayerRemovedEvent>("PlayerRemovedEvent", basicAi.PlayerRemoved);
		}
	}
}
