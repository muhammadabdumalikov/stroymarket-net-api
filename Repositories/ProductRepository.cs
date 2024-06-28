using Microsoft.EntityFrameworkCore;
using stroymarket_net_api.Data;
using stroymarket_net_api.Entities;

namespace stroymarket_net_api.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ProductStoreContext dbContext;

    public ProductRepository(ProductStoreContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task CreateAsync(Product product)
    {
        dbContext.Products.Add(product);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await dbContext.Products.Where(product => product.Id == id).ExecuteDeleteAsync();
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await dbContext.Products.AsNoTracking().ToListAsync();
    }

    public async Task<Product?> GetOneAsync(int id)
    {
        return await dbContext.Products.FindAsync(id);
    }

    public async Task UpdateAsync(Product product)
    {
        dbContext.Products.Update(product);
    }
}