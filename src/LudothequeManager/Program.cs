using LudothequeManager.Models;
using LudothequeManager.Data;

using var db = new LudothequeDbContext();

if (!db.Database.CanConnect())
{
    Console.WriteLine("Unable to connect to the database.");
    return;
}

if (!db.Games.Any())
{
    var seedGames = new List<Game>
    {
        new Game { Name = "Les Aventuriers du Rail", Publisher = "Days of Wonder" },
        new Game { Name = "Dixit", Publisher = "Libellud" },
        new Game { Name = "Catan", Publisher = "Kosmos" },
        new Game { Name = "Azul", Publisher = "Plan B Games" },
        new Game { Name = "7 Wonders", Publisher = "Repos Production" },
    };

    db.Games.AddRange(seedGames);
    db.SaveChanges();
}

var storedGames = db.Games.ToList();

Console.WriteLine("List of games: ");
foreach (var game in storedGames)
{
    Console.WriteLine($"[{game.Id}] {game.Name} by {game.Publisher}");
}


if (!db.Members.Any())
{
    var seedMembers = new List<Member>
    {
        new Member("Alice", "Martin", "alice.martin@example.com"),
        new Member("Bruno", "Lefèvre", "bruno.lefevre@example.com"),
        new Member("Chloé", "Dubois", "chloe.dubois@example.com"),
    };

    db.Members.AddRange(seedMembers);
    db.SaveChanges();
}

var dixit = db.Games.First(game => game.Name == "Dixit");
Console.WriteLine($"Dixit available: {dixit.Status == GameStatus.Available}");
if (dixit.Status == GameStatus.Available)
{
    dixit.CheckOut(db.Members.First(member => member.FirstName == "Alice"));
    db.SaveChanges();
}

Console.WriteLine($"Dixit available: {dixit.Status == GameStatus.Available}");


// var members = new List<Member>
// {
//     new Member(1, "Alice", "Martin", "alice.martin@example.com"),
//     new Member(2, "Bruno", "Lefèvre", "bruno.lefevre@example.com"),
//     new Member(3, "Chloé", "Dubois", "chloe.dubois@example.com"),
// };

// var alice = members.First(member => member.Id == 1);
// var bruno = members.First(member => member.Id == 2);
// var chloe = members.First(member => member.Id == 3);

// games.First(game => game.Id == 2).CheckOut(alice);
// games.First(game => game.Id == 4).CheckOut(bruno);

// var unavailableCount = games.Count(game => !game.IsAvailable);
// var availableCount = games.Count(game => game.IsAvailable);

// foreach (var game in games)
// {
//     Console.WriteLine($"[{game.Id}] {game.Name} by {game.Publisher} is {(game.IsAvailable ? "available" : "not available")}");
// }

// Console.WriteLine($"Number of unavailable games: {unavailableCount}");
// Console.WriteLine($"Number of available games: {availableCount}");

// Console.WriteLine();
// Console.WriteLine("--- Members ---");
// chloe.Deactivate();

// foreach (var member in members)
// {
//     Console.WriteLine($"[{member.Id}] {member.FullName} ({member.Email}) is {(member.IsActive ? "active" : "inactive")}");
// }

// Console.WriteLine();
// Console.WriteLine("--- Checkout scenario: Catan ---");
// var catan = games.First(game => game.Id == 3);

// // 1. Inactive member: should be refused
// try
// {
//     catan.CheckOut(chloe);
// }
// catch (InvalidOperationException ex)
// {
//     Console.WriteLine($"Checkout by {chloe.FullName} refused -> {ex.Message}");
// }

// // 2. Active member: should succeed
// catan.CheckOut(alice);
// Console.WriteLine($"Checkout by {alice.FullName} -> {catan.Name} available: {catan.IsAvailable}");

// // 3. Game already checked out: should be refused
// try
// {
//     catan.CheckOut(bruno);
// }
// catch (InvalidOperationException ex)
// {
//     Console.WriteLine($"Checkout by {bruno.FullName} refused -> {ex.Message}");
// }

// // 4. Return then checkout again: should succeed
// catan.Return();
// Console.WriteLine($"Return -> {catan.Name} available: {catan.IsAvailable}");
// catan.CheckOut(bruno);
// Console.WriteLine($"Checkout by {bruno.FullName} -> {catan.Name} available: {catan.IsAvailable}");

// // 5. Invalid member: constructor should refuse an empty email
// Console.WriteLine();
// try
// {
//     _ = new Member(4, "David", "Petit", "");
// }
// catch (ArgumentException ex)
// {
//     Console.WriteLine($"Member creation refused -> {ex.Message}");
// }
