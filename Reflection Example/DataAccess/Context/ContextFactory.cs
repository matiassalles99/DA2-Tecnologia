using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Context;

public enum ContextType { Memory, SQL }

public class ContextFactory : IDesignTimeDbContextFactory<PetServerContext>
{

  public PetServerContext CreateDbContext(string[] args)
  {
    return GetNewContext();
  }

  public static PetServerContext GetNewContext(ContextType type = ContextType.SQL)
  {
    var builder = new DbContextOptionsBuilder<PetServerContext>();
    DbContextOptions options = null;

    if (type == ContextType.Memory)
    {
      options = GetMemoryConfig(builder);
    }
    else
    {
      options = GetSqlConfig(builder);
    }

    return new PetServerContext(options);
  }

  private static DbContextOptions GetMemoryConfig(DbContextOptionsBuilder builder)
  {
    builder.UseInMemoryDatabase("PetServerDB");

    return builder.Options;
  }

  private static DbContextOptions GetSqlConfig(DbContextOptionsBuilder builder)
  {
    string directory = Directory.GetCurrentDirectory();

    IConfigurationRoot configuration = new ConfigurationBuilder()
    .SetBasePath(directory)
    .AddJsonFile("appsettings.json")
    .Build();

    var connectionString = configuration.GetConnectionString(@"PetServerDB");
    builder.UseSqlServer(connectionString);
    return builder.Options;
  }

}
