using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using stroymarket_net_api.Entities;

namespace stroymarket_net_api.Repositories;

public class ProductRepository
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

    public IEnumerable<Product> GetAll()
    {
        return products;
    }

    public Product? GetOne(int id)
    {
        return products.Find(product => product.Id == id);
    }

    public void Create(Product product)
    {
        product.Id = products.Max(product => product.Id) + 1;
        products.Add(product);
    }

    public void Update(Product product)
    {

    }

    public void Delete(int id)
    {

    }
}