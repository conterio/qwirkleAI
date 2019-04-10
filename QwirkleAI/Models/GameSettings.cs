namespace QwirkleAI.Models
{
    public class GameSettings
    {
        private const int DefaultHandSize = 6;
        public string Name { get; set; }
        public int HumanTimeout { get; set; }
        public int AITimeout { get; set; }
        public int NumberOfTiles { get; set; }
        public int HandSize { get; set; } = DefaultHandSize;
    }
}