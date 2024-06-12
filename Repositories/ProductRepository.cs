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

    public void Create(Product product)
    {
        dbContext.Products.Add(product);
        dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        dbContext.Products.Where(product => product.Id == id).ExecuteDelete();
    }

    public IEnumerable<Product> GetAll()
    {
        return dbContext.Products.AsNoTracking().ToList();
    }

    public Product? GetOne(int id)
    {
        return dbContext.Products.Find(id);
    }

    public void Update(Product product)
    {
        dbContext.Products.Update(product);
    }
}