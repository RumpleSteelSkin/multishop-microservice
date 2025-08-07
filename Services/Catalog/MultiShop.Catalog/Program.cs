using MultiShop.Catalog.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCatalogServices(builder.Configuration);

var app = builder.Build();

app.AddCatalogApp();