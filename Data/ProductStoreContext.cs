using System.Reflection;
using Microsoft.EntityFrameworkCore;
using stroymarket_net_api.Entities;

namespace stroymarket_net_api.Data;

public class ProductStoreContext : DbContext
{
    public ProductStoreContext(DbContextOptions<ProductStoreContext> options)
        : base(options)
    {

    }

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}