using MultiShop.Order.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOrderApplicationServices(builder.Configuration);

var app = builder.Build();

app.AddOrderApplicationApp();