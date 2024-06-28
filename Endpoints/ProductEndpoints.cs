using stroymarket_net_api.Authorization;
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

        ProductGroup.MapGet("", async (IProductRepository repository) => (await repository.GetAllAsync()).Select(product => product.AsDto()))
        .RequireAuthorization(Policies.WriteAccess);

        ProductGroup.MapGet("/{id}", async (IProductRepository repository, int id) =>
        {
            Product? product = await repository.GetOneAsync(id);

            if (product == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(product);
        }
        ).WithName(GetProductEndpoint)
        .RequireAuthorization(Policies.ReadAccess);

        ProductGroup.MapPost("", async (IProductRepository repository, CreateProductDto createProductDto) =>
        {
            Product product = new()
            {
                NameUz = createProductDto.NameUz,
                NameRu = createProductDto.NameRu,
                Price = createProductDto.Price,
                ImageUri = createProductDto.ImageUri
            };

            await repository.CreateAsync(product);

            return Results.CreatedAtRoute(GetProductEndpoint, new { id = product.Id }, product);
        })
        .RequireAuthorization();

        return ProductGroup;

    }
}