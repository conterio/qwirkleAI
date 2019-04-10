using System;
using System.Collections.Generic;
using System.Text;

namespace QwirkleAI
{
    public interface IAIBusi
    {
        void CreateAIJoinGame(string connectionId, Guid gameId);
        void RemoveAI(string connectionId);
    }
    public class AIBusi : IAIBusi
    {
        private IAIRepository _aiRepository;
        public AIBusi(IAIRepository aiRepository)
        {
            _aiRepository = aiRepository;
        }
        public void CreateAIJoinGame(string connectionId, Guid gameId)
        {
            _aiRepository.AddAI(connectionId);
            //TODO join game
        }

        public void RemoveAI(string connectionId)
        {
            _aiRepository.RemoveAI(connectionId);
        }
    }
}
