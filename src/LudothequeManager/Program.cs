using LudothequeManager.Models;

Console.WriteLine("Ludothèque Manager");
var games = new List<Game>
{
    new Game { Id = 1, Name = "Les Aventuriers du Rail", Publisher = "Days of Wonder" },
    new Game { Id = 2, Name = "Dixit", Publisher = "Libellud", IsAvailable = false },
    new Game { Id = 3, Name = "Catan", Publisher = "Kosmos" },
    new Game { Id = 4, Name = "Azul", Publisher = "Plan B Games", IsAvailable = false },
    new Game { Id = 5, Name = "7 Wonders", Publisher = "Repos Production" },
};

var unavailableCount = games.Count(game => !game.IsAvailable);
var availableCount = games.Count(game => game.IsAvailable);

foreach (var game in games)
{
    Console.WriteLine($"[{game.Id}] {game.Name} by {game.Publisher} is {(game.IsAvailable ? "available" : "not available")}");
}

Console.WriteLine($"Number of unavailable games: {unavailableCount}");
Console.WriteLine($"Number of available games: {availableCount}");