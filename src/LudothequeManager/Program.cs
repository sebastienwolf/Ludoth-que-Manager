using LudothequeManager.Models;

Console.WriteLine("Ludothèque Manager");
var games = new List<Game>
{
    new Game { Id = 1, Name = "Les Aventuriers du Rail", Publisher = "Days of Wonder" },
    new Game { Id = 2, Name = "Dixit", Publisher = "Libellud" },
    new Game { Id = 3, Name = "Catan", Publisher = "Kosmos" },
    new Game { Id = 4, Name = "Azul", Publisher = "Plan B Games" },
    new Game { Id = 5, Name = "7 Wonders", Publisher = "Repos Production" },
};

games.First(game => game.Id == 2).CheckOut();
games.First(game => game.Id == 4).CheckOut();

var unavailableCount = games.Count(game => !game.IsAvailable);
var availableCount = games.Count(game => game.IsAvailable);

foreach (var game in games)
{
    Console.WriteLine($"[{game.Id}] {game.Name} by {game.Publisher} is {(game.IsAvailable ? "available" : "not available")}");
}

Console.WriteLine($"Number of unavailable games: {unavailableCount}");
Console.WriteLine($"Number of available games: {availableCount}");

Console.WriteLine();
Console.WriteLine("--- Checkout scenario: Catan ---");
var catan = games.First(game => game.Id == 3);

// 1. First checkout: should succeed
catan.CheckOut();
Console.WriteLine($"Checkout #1 -> {catan.Name} available: {catan.IsAvailable}");

// 2. Second checkout: should be refused
try
{
    catan.CheckOut();
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Checkout #2 refused -> {ex.Message}");
}

// 3. Return then checkout again: should succeed
catan.Return();
Console.WriteLine($"Return -> {catan.Name} available: {catan.IsAvailable}");
catan.CheckOut();
Console.WriteLine($"Checkout #3 -> {catan.Name} available: {catan.IsAvailable}");
