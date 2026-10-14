namespace LudothequeManager.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Publisher { get; set; } = "";
        public bool IsAvailable { get; set; } = true;
    }
}