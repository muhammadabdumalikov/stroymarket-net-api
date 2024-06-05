using stroymarket_net_api.Entities;

List<Product> products = new()
{
  new Product()
  {
    Id = 1,
    NameRu = "Ruscha",
    NameUz = "Uzbekcha",
    Price = 19.11M,
    ImageUri = "string",
    CreatedAt = new DateTime(2024, 05, 10)
  }
};

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
