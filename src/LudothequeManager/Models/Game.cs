namespace LudothequeManager.Models;

public class Game
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Publisher { get; set; } = "";
    public GameStatus Status { get; private set; } = GameStatus.Available;
    private readonly List<Loan> _loans = new();
    public IReadOnlyCollection<Loan> Loans => _loans;

    public Loan CheckOut(Member member)
    {
        if (!member.IsActive)
        {
            throw new InvalidOperationException($"{member.FullName} is not an active member.");
        }
        if (Status != GameStatus.Available)
        {
            throw new InvalidOperationException($"{Name} is not available ({Status}).");
        }

        var loan = new Loan(this, member);
        _loans.Add(loan);
        Status = GameStatus.CheckedOut;
        return loan;
    }

    public void Return()
    {
        var loan = _loans.FirstOrDefault(loan => loan.ReturnedAt == null);
        if (loan == null)
        {
            throw new InvalidOperationException($"{Name} is not currently checked out.");
        }
        loan.Return();
        Status = GameStatus.Available;
    }
}
