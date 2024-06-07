using stroymarket_net_api.Dtos;

namespace stroymarket_net_api.Entities;

public static class EntityExtensions
{
    public static ProductDto AsDto(this Product product){
    return new ProductDto(
      product.Id,
      product.NameUz,
      product.NameRu,
      product.Price,
      product.CreatedAt,
      product.ImageUri
    );
    }
}