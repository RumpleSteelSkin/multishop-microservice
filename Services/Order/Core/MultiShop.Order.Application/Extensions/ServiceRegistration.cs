using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MultiShop.Order.Application.Extensions;

public static class ServiceRegistration
{
    public static IServiceCollection AddOrderApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(opt => { opt.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); });
        return services;
    }
}