using System.Collections.Concurrent;

namespace QwirkleAI
{
    public interface IAIRepository
    {
        BasicAI AddAI();
        void RemoveAI(string connectionId);
    }

    public class AIRepository : IAIRepository
    {
        private ConcurrentDictionary<string, BasicAI> AIs { get; set; }
        public AIRepository()
        {
            AIs = new ConcurrentDictionary<string, BasicAI>();
        }

        public BasicAI AddAI()
        {
            var basicAi = new BasicAI();
			AIs.AddOrUpdate(basicAi.Id, basicAi, (_, __) => basicAi);
			return basicAi;
        }

        public void RemoveAI(string connectionId)
        {
            //TODO might want to handle if we cant clean up AI
            AIs.TryRemove(connectionId, out var _);
        }
    }
}