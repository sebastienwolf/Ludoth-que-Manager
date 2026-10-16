namespace LudothequeManager.Models;

public class Loan
{
    public int Id { get; private set; }

    public int GameId { get; private set; }
    public Game Game { get; private set; } = null!;

    public int MemberId { get; private set; }
    public Member Member { get; private set; } = null!;


    public DateTime CheckedOutAt { get; private set; }
    public DateTime? ReturnedAt { get; private set; } = null;

    private Loan() { } // Required by EF Core

    public Loan(Game game, Member member)
    {
        Game = game;
        Member = member;
        CheckedOutAt = DateTime.UtcNow;
    }

    public void Return()
    {
        if (ReturnedAt.HasValue)
        {
            throw new InvalidOperationException($"{Game.Name} has already been returned.");
        }

        ReturnedAt = DateTime.UtcNow;
    }
}