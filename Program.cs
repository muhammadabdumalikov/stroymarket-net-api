using stroymarket_net_api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapProductsEndpoints();

app.Run();
