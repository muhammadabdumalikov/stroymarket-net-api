using stroymarket_net_api.Entities;

namespace stroymarket_net_api.Repositories;

public interface IProductRepository
{
    Task CreateAsync(Product product);
    Task DeleteAsync(int id);
    Task<Product?> GetOneAsync(int id);
    Task<IEnumerable<Product>> GetAllAsync();
    Task Update(Product product);
}