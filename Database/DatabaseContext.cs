using Backend.Database.Models;

using Microsoft.EntityFrameworkCore;

namespace Backend.Database;

public class DatabaseContext : DbContext
{
    public DbSet<Photo> Photos { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Event> Events {  get; set; } 
    public DbSet<EventPhoto> EventsPhoto { get; set; }

    public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Ticket> Tickets { get; set; }

    private IConfiguration _config { get; init; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration config) : base(options)
    {
        _config = config;

        Database.Migrate();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var host = _config["DatabaseConnection:Host"];
        var databaseName = _config["DatabaseConnection:DatabaseName"];
        var username = _config["DatabaseConnection:Username"];
        var password = _config["DatabaseConnection:Password"];

        optionsBuilder.UseNpgsql($"Host={host};Database={databaseName};Username={username};Password={password}");
    }
}