using stroymarket_net_api.Data;
using stroymarket_net_api.Endpoints;
using stroymarket_net_api.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IProductRepository, ProductRepositoryX>();

var connectionStr = builder.Configuration.GetConnectionString("ProductStoreContext");
builder.Services.AddNpgsql<ProductStoreContext>(connectionStr);

var app = builder.Build();

app.Services.InitializeDb();

app.MapProductsEndpoints();

app.Run();
