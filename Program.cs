using stroymarket_net_api.Data;
using stroymarket_net_api.Endpoints;
using stroymarket_net_api.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRepositories(builder.Configuration);

var app = builder.Build();

app.Services.InitializeDb();

app.MapProductsEndpoints();

app.Run();
