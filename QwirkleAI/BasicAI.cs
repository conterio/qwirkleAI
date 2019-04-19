using QwirkleAI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QwirkleAI
{
    public class BasicAI
    {
		private IAIRepository _aIRepository;
        public string Id { get; set; }
        private AIHub aIHub { get; set; }
        private Game game { get; set; }

        public BasicAI(IAIRepository aIRepository)
        {
            _aIRepository = aIRepository;
            aIHub = new AIHub(this);
            Id = aIHub.GetId();
            game = new Game();
        }

        public void JoinGame(Guid gameId)
        {
            aIHub.JoinGame(gameId);
        }

        public void TakeTurn(TurnEvent turnEvent)
        {

            //Check to see if it's our turn
            if (turnEvent.CurrentPlayerId == Id)
            {
                //It's our turn!!!
            }
        }

        public void EndTurn(EndTurnEvent endTurnEvent)
        {
            //Add new tiles to our hand
            game.CurrentHand.AddRange(endTurnEvent.NewTiles);
        }

        public void StartGame(StartGameEvent startGameEvent)
        {
			//Set our starting hand
			int order = 0;
            game.CurrentHand.AddRange(startGameEvent.StartingHand);
            foreach (var playerId in startGameEvent.PlayerOrder)
            {
                game.Players[playerId].TurnOrder = order++;
            }
        }

        public void EndGame(EndGameEvent endGameEvent)
        {
			_aIRepository.RemoveAI(Id);
        }

        public void GameInfo(GameInfoEvent gameInfoEvent)
        {
            //TODO revisit what info we are sending
            game.GameSettings = gameInfoEvent.GameSettings;
            foreach (var player in gameInfoEvent.Players)
            {
				game.Players.Add(player.PlayerId, new Player {Name = player.Name});
            }
        }

        public void PlayerJoined(PlayerJoinedEvent playerJoinedEvent)
        {
			game.Players.Add(playerJoinedEvent.PlayerId, new Player { Name = playerJoinedEvent.Name });
        }

        public void PlayerRemoved(PlayerRemovedEvent playerRemovedEvent)
        {
            //TODO did they leave the lobby or the game?
            var player = game.Players[playerRemovedEvent.CurrentPlayerId];
            player.StillPlaying = false;
        }
    }
}
