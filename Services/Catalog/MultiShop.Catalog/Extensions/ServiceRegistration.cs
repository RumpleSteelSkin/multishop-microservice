using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MultiShop.Catalog.Services.CategoryServices;
using MultiShop.Catalog.Services.FeatureSliderServices;
using MultiShop.Catalog.Services.ProductServices;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Extensions;

public static class ServiceRegistration
{
    public static IServiceCollection AddCatalogServices(this IServiceCollection services, IConfiguration configuration)
    {
        #region JWT Settings
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
        {
            opt.Authority = configuration["Jwt:IdentityServerUrl"];
            opt.Audience = configuration["Jwt:Audience"];
            opt.RequireHttpsMetadata = false;
        });
        #endregion
        
        #region API Configuration
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddControllers();
        #endregion

        #region AutoMapper Configuration
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        #endregion

        #region MongoDB Configuration
        services.Configure<DatabaseSettings>(configuration.GetSection("DatabaseSettings"));
        services.AddSingleton<IDatabaseSettings>(sp => 
            sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);
        services.AddSingleton<IMongoClient>(sp =>
            new MongoClient(sp.GetRequiredService<IDatabaseSettings>().ConnectionString));
        #endregion

        #region Application Services
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IFeatureSliderService, FeatureSliderService>();
        #endregion

        return services;
    }
}