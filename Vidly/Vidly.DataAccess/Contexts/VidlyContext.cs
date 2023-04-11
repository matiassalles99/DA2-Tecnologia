using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Vidly.Domain.Entities;

namespace Vidly.DataAccess.Contexts;

public class VidlyContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Session> Sessions { get; set; }

    public VidlyContext(DbContextOptions options) : base(options) { }
    public VidlyContext() : base() { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Ejemplo de Fluent API
        modelBuilder.Entity<Movie>()
            .Property(m => m.Title)
            .IsRequired()
            .HasMaxLength(50);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var directory = Directory.GetCurrentDirectory();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(directory)
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("VidlyDB");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}