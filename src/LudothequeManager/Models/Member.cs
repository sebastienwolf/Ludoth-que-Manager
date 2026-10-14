namespace LudothequeManager.Models;

public class Member
{
    public int Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public bool IsActive { get; private set; } = true;

    public string FullName => $"{FirstName} {LastName}";

    public Member(int id, string firstName, string lastName, string email)
    {
        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("First name, last name, and email must be provided.");
        }

        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public void Deactivate()
    {
        if (!IsActive)
        {
            throw new InvalidOperationException($"{FullName} is already deactivated.");
        }

        IsActive = false;
    }

    public void Activate()
    {
        IsActive = true;
    }
}
