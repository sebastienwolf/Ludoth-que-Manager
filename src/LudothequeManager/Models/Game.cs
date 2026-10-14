namespace LudothequeManager.Models;

public class Game
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Publisher { get; set; } = "";
    public bool IsAvailable { get; private set; } = true;

    public void CheckOut()
    {
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
