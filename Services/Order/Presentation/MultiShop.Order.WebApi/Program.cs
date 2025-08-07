using MultiShop.Order.Application.Extensions;
using MultiShop.Order.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOrderWebApiServices(builder.Configuration);
builder.Services.AddOrderApplicationServices(builder.Configuration);

var app = builder.Build();

app.AddOrderWebApiApp();