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

app.MapGet("/products", () => products);

app.MapGet("/products/{id}", (int id) =>
{
  Product? product = products.Find(game => game.Id == id);

  if (product == null)
  {
    return Results.NotFound();
  }

  return Results.Ok(product);
}
).WithName(GetProductEndpoint);

app.MapPost("/products", (Product product) =>
{
  product.Id = products.Max(product => product.Id) + 1;
  products.Add(product);

  return Results.CreatedAtRoute(GetProductEndpoint, new { id = product.Id }, product);
});

app.Run();
