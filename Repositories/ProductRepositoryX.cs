using stroymarket_net_api.Entities;

namespace stroymarket_net_api.Repositories;

public class ProductRepositoryX : IProductRepository
{
    private readonly List<Product> products = new()
    {
        new()
        {
            Id = 1,
            NameRu = "Ruscha",
            NameUz = "Uzbekcha",
            Price = 19.11M,
            ImageUri = "string",
            CreatedAt = new DateTime(2024, 05, 10)
        },
        new()
        {
            Id = 2,
            NameRu = "Ruscha",
            NameUz = "Uzbekcha",
            Price = 19.11M,
            ImageUri = "string",
            CreatedAt = new DateTime(2024, 05, 10)
        }
    };

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await Task.FromResult(products);
    }

    public async Task<Product?> GetOneAsync(int id)
    {
        return await Task.FromResult(products.Find(product => product.Id == id));
    }

    public async Task CreateAsync(Product product)
    {
        product.Id = products.Max(product => product.Id) + 1;
        products.Add(product);

        await Task.CompletedTask;
    }

    public async Task UpdateAsync(Product product)
    {
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(int id)
    {
        await Task.CompletedTask;
    }
}