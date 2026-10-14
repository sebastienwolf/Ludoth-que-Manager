using LudothequeManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LudothequeManager.Data;

public class LudothequeDbContext : DbContext
{
    public DbSet<Game> Games => Set<Game>();
    public DbSet<Member> Members => Set<Member>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.Local.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var connectionString = configuration.GetConnectionString("LudothequeDb");
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException(
                "Connection string 'LudothequeDb' is missing. Copy appsettings.Local.example.json to appsettings.Local.json and fill in your password.");
        }

        optionsBuilder.UseSqlServer(connectionString);
    }
}
