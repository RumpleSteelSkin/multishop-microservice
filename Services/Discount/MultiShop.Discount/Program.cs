using MultiShop.Discount.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDiscountServices(builder.Configuration);

var app = builder.Build();

app.AddDiscountApp();