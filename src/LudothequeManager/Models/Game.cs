namespace LudothequeManager.Models;

public class Game
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Publisher { get; set; } = "";
    public bool IsAvailable { get; private set; } = true;

    public void CheckOut(Member member)
    {
        if (!member.IsActive)
        {
            throw new InvalidOperationException($"{member.FullName} is not an active member.");
        }
        if (!IsAvailable)
        {
            throw new InvalidOperationException($"{Name} is already checked out.");
        }

        IsAvailable = false;
    }

    public void Return()
    {
        IsAvailable = true;
    }
}
