using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class ContextDb: DbContext
{
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }

    public ContextDb(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
    }
    

}