using stroymarket_net_api.Endpoints;
using stroymarket_net_api.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IProductRepository, ProductRepository>();

var connectionStr = builder.Configuration.GetConnectionString("ProductStoreContext");

var app = builder.Build();

app.MapProductsEndpoints();

app.Run();
