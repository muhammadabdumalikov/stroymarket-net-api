using Microsoft.EntityFrameworkCore;
using stroymarket_net_api.Repositories;

namespace stroymarket_net_api.Data;

public static class DataExtensions
{
    public static async Task InitializeDbAsync(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ProductStoreContext>();
        await dbContext.Database.MigrateAsync();
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