using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Context;

public class PetServerContext : DbContext
{
  DbSet<Pet> Pets { get; set; }
  DbSet<Owner> Owners { get; set; }

  public PetServerContext(DbContextOptions options) : base(options) { }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if (!optionsBuilder.IsConfigured)
    {
      string directory = Directory.GetCurrentDirectory();

      IConfigurationRoot configuration = new ConfigurationBuilder()
      .SetBasePath(directory)
      .AddJsonFile("appsettings.json")
      .Build();

      var connectionString = configuration.GetConnectionString(@"PetServerDB");
      optionsBuilder.UseSqlServer(connectionString);
    }
  }

}
