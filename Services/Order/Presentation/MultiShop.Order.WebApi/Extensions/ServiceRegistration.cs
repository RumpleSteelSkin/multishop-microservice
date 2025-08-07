using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

namespace MultiShop.Order.WebApi.Extensions;

public static class ServiceRegistration
{
    public static IServiceCollection AddOrderApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<GetOrderDetailByIdQueryHandler>();
        services.AddScoped<GetOrderDetailQueryHandler>();
        services.AddScoped<CreateOrderDetailCommandHandler>();
        services.AddScoped<UpdateOrderDetailCommandHandler>();
        services.AddScoped<RemoveOrderDetailCommandHandler>();

        services.AddScoped<GetAddressByIdQueryHandler>();
        services.AddScoped<GetAddressQueryHandler>();
        services.AddScoped<CreateAddressCommandHandler>();
        services.AddScoped<UpdateAddressCommandHandler>();
        services.AddScoped<RemoveAddressCommandHandler>();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddControllers();
        return services;
    }
}