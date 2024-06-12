using Microsoft.EntityFrameworkCore;

namespace stroymarket_net_api.Data;

public static class DataExtensions
{
    public static void InitializeDb(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ProductStoreContext>();
        dbContext.Database.Migrate();
    }
}