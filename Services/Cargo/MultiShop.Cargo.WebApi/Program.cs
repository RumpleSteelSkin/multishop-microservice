using Microsoft.AspNetCore.Authentication.JwtBearer;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.BusinessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.Repositories;

var builder = WebApplication.CreateBuilder(args);

#region JWT Settings

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["Jwt:IdentityServerUrl"];
    opt.Audience = builder.Configuration["Jwt:Audience"];
    opt.RequireHttpsMetadata = false;
});

#endregion

builder.Services.AddDbContext<CargoContext>();
builder.Services.AddScoped<ICargoCompanyDal, CargoCompanyDal>();
builder.Services.AddScoped<ICargoCompanyService, CargoCompanyManager>();
builder.Services.AddScoped<ICargoOperationDal, CargoOperationDal>();
builder.Services.AddScoped<ICargoOperationService, CargoOperationManager>();
builder.Services.AddScoped<ICargoDetailDal, CargoDetailDal>();
builder.Services.AddScoped<ICargoDetailService, CargoDetailManager>();
builder.Services.AddScoped<ICargoCustomerDal, CargoCustomerDal>();
builder.Services.AddScoped<ICargoCustomerService, CargoCustomerManager>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();

app.Run();