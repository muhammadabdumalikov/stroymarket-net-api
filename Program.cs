using stroymarket_net_api.Authorization;
using stroymarket_net_api.Data;
using stroymarket_net_api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRepositories(builder.Configuration);

builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization(options => 
{
  options.AddPolicy(Policies.ReadAccess, builder =>
  {
    builder.RequireClaim("scope", "product:read");
  });
});

var app = builder.Build();

await app.Services.InitializeDbAsync();

app.MapProductsEndpoints();

app.Run();
