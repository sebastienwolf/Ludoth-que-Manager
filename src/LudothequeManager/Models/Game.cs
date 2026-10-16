namespace LudothequeManager.Models;

public class Game
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Publisher { get; set; } = "";
    public GameStatus Status { get; private set; } = GameStatus.Available;

    public void CheckOut(Member member)
    {
        if (!member.IsActive)
        {
            throw new InvalidOperationException($"{member.FullName} is not an active member.");
        }
        if (Status != GameStatus.Available)
        {
            throw new InvalidOperationException($"{Name} is not available ({Status}).");
        }

        Status = GameStatus.CheckedOut;
    }

    public void Return()
    {
        Status = GameStatus.Available;
    }
}
