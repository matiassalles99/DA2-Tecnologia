using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Vidly.DataAccess.Contexts;

// Para testing usar SQLite, por defecto usar SQLServer
public enum ContextType { SQLite, SQLServer }

public class ContextFactory : IDesignTimeDbContextFactory<VidlyContext>
{
    public VidlyContext CreateDbContext(string[] args)
    {
        return GetNewContext();
    }

    public static VidlyContext GetNewContext(ContextType type = ContextType.SQLServer)
    {
        var builder = new DbContextOptionsBuilder<VidlyContext>();
        DbContextOptions options = null;

        if (type == ContextType.SQLite)
        {
            options = GetSqliteConfig(builder);
        }
        else
        {
            options = GetSqlServerConfig(builder);
        }

        return new VidlyContext(options);
    }

    private static DbContextOptions GetSqliteConfig(DbContextOptionsBuilder builder)
    {
        var connection = new SqliteConnection("Filename=:memory:");
        builder.UseSqlite(connection);
        return builder.Options;
    }

    private static DbContextOptions GetSqlServerConfig(DbContextOptionsBuilder builder)
    {
        //Gets directory from startup project being used, NOT this class's path 
        var directory = Directory.GetCurrentDirectory();

        var configuration = new ConfigurationBuilder()
            .SetBasePath(directory)
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("VidlyDB");
        builder.UseSqlServer(connectionString);
        return builder.Options;
    }
}