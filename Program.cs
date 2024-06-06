using stroymarket_net_api.Entities;

const string GetProductEndpoint = "GetProductEnpoint";

List<Product> products = new()
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

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var ProductGroup = app.MapGroup("/product");

ProductGroup.MapGet("", () => products);

ProductGroup.MapGet("/{id}", (int id) =>
{
  Product? product = products.Find(game => game.Id == id);

  if (product == null)
  {
    return Results.NotFound();
  }

  return Results.Ok(product);
}
).WithName(GetProductEndpoint);

ProductGroup.MapPost("", (Product product) =>
{
  product.Id = products.Max(product => product.Id) + 1;
  products.Add(product);

  return Results.CreatedAtRoute(GetProductEndpoint, new { id = product.Id }, product);
});

app.Run();
