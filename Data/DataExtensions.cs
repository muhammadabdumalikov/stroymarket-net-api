using Microsoft.EntityFrameworkCore;
using stroymarket_net_api.Repositories;

namespace stroymarket_net_api.Data;

public static class DataExtensions
{
    public static void InitializeDb(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ProductStoreContext>();
        dbContext.Database.Migrate();
    }

    public static IServiceCollection AddRepositories(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var connectionStr = configuration.GetConnectionString("ProductStoreContext");
        services.AddNpgsql<ProductStoreContext>(connectionStr).AddSingleton<IProductRepository, ProductRepositoryX>();

        return services;
    }
}