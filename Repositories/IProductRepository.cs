using stroymarket_net_api.Entities;

namespace stroymarket_net_api.Repositories;

public interface IProductRepository
{
    void Create(Product product);
    void Delete(int id);
    Product? GetOne(int id);
    IEnumerable<Product> GetAll();
    void Update(Product product);
}