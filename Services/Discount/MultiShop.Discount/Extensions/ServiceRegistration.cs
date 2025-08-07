using MultiShop.Discount.Context;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Extensions;

public static class ServiceRegistration
{
    public static IServiceCollection AddDiscountServices(this IServiceCollection services, IConfiguration configuration)
    {
        #region Service Registrations

        services.AddTransient<DapperContext>();

        services.AddTransient<IDiscountService, DiscountService>();

        #endregion

        #region API Configuration

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        #endregion

        return services;
    }
}