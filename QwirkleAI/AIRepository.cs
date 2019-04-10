using System.Collections.Concurrent;

namespace QwirkleAI
{
    public interface IAIRepository
    {
        void AddAI(string connectionId);
        void RemoveAI(string connectionId);
    }

    public class AIRepository : IAIRepository
    {
        private ConcurrentDictionary<string, BasicAI> AIs { get; set; }
        public AIRepository()
        {
            AIs = new ConcurrentDictionary<string, BasicAI>();
        }

        public void AddAI(string connectionId)
        {
            var basicAi = new BasicAI();
            AIs.AddOrUpdate(connectionId, basicAi, (_, __) => basicAi);
        }

        public void RemoveAI(string connectionId)
        {
            //TODO might want to handle if we cant clean up AI
            AIs.TryRemove(connectionId, out var _);
        }
    }
}