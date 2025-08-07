using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Persistence.Context;
using MultiShop.Order.Persistence.Repositories;

namespace MultiShop.Order.WebApi.Extensions;

public static class ServiceRegistration
{
    public static IServiceCollection AddOrderWebApiServices(this IServiceCollection services,
        IConfiguration configuration)
    {

        services.AddDbContext<OrderContext>();
        
        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
        
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