using stroymarket_net_api.Entities;
using stroymarket_net_api.Repositories;

namespace stroymarket_net_api.Endpoints;

public static class ProductEndpoints
{
    const string GetProductEndpoint = "GetProductEnpoint";

    public static RouteGroupBuilder MapProductsEndpoints(this IEndpointRouteBuilder routes)
    {
        ProductRepository repository = new();

        var ProductGroup = routes.MapGroup("/product").WithParameterValidation();

        ProductGroup.MapGet("", () => repository.GetAll());

        ProductGroup.MapGet("/{id}", (int id) =>
        {
            Product? product = repository.GetOne(id);

            if (product == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(product);
        }
        ).WithName(GetProductEndpoint);

        ProductGroup.MapPost("", (Product product) =>
        {
            repository.Create(product);

            return Results.CreatedAtRoute(GetProductEndpoint, new { id = product.Id }, product);
        });

        return ProductGroup;

    }
}