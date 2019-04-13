using System;
using System.Collections.Generic;
using System.Text;

namespace QwirkleAI
{
    public interface IAIBusi
    {
		void CreateAIJoinGame(Guid gameId);

		void RemoveAI(string connectionId);
    }
    public class AIBusi : IAIBusi
    {
        private IAIRepository _aiRepository;
        public AIBusi(IAIRepository aiRepository)
        {
            _aiRepository = aiRepository;
        }

		public void CreateAIJoinGame(Guid gameId)
		{
			var ai = _aiRepository.AddAI();
			ai.JoinGame(gameId);
		}



		public void RemoveAI(string connectionId)
        {
            _aiRepository.RemoveAI(connectionId);
        }

		public void TakeTurn()
		{

		}
    }
}
