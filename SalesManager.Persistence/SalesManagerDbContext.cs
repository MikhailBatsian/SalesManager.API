using Microsoft.EntityFrameworkCore;
using SalesManager.Domain.Entities;
using System.Reflection;

namespace SalesManager.Persistence;
public class SalesManagerDbContext : DbContext
{
    public SalesManagerDbContext(DbContextOptions<SalesManagerDbContext> options) : base(options)
    {
    }

    public DbSet<Sale> Sales { get; set; }

    public DbSet<SalesAmount> SalesAmount { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
