using stroymarket_net_api.Dtos;
using stroymarket_net_api.Entities;
using stroymarket_net_api.Repositories;

namespace stroymarket_net_api.Endpoints;

public static class ProductEndpoints
{
    const string GetProductEndpoint = "GetProductEnpoint";

    public static RouteGroupBuilder MapProductsEndpoints(this IEndpointRouteBuilder routes)
    {
        var ProductGroup = routes.MapGroup("/product").WithParameterValidation();

        ProductGroup.MapGet("", (IProductRepository repository) => repository.GetAll().Select(product => product.AsDto()));

        ProductGroup.MapGet("/{id}", (IProductRepository repository, int id) =>
        {
            Product? product = repository.GetOne(id);

            if (product == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(product);
        }
        ).WithName(GetProductEndpoint);

        ProductGroup.MapPost("", (IProductRepository repository, CreateProductDto createProductDto) =>
        {
            Product product = new()
            {
                NameUz = createProductDto.NameUz,
                NameRu = createProductDto.NameRu,
                Price = createProductDto.Price,
                ImageUri = createProductDto.ImageUri
            };

            repository.Create(product);

            return Results.CreatedAtRoute(GetProductEndpoint, new { id = product.Id }, product);
        });

        return ProductGroup;

    }
}