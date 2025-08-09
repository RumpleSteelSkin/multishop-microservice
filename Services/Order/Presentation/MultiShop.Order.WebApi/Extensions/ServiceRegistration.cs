using System.Security.Cryptography;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
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
        #region  JWT Settings
        
        string n = "7VmAblaUk8xpBr5KaxUye9zlQigKtK1g17biSkN6olexWqT1vUHUYsmCLOvrbmrLT8IhKWILijP06omDV5pi_o7hEifH0i5eNJJVbfoXS0ST_KTE3hCXExOyZh-YOcxZW9zsG3fNuQCNAEWMCLvVhpMHqwxF0UGDmdqJa1b8hdn2FulTezS65ZTEU_dXIU_3uvz_z_PwU6TI1LqnuUjoMqO2rpcbYnkZ728FcKpepPpSz4i26gvcve2wxuUoK3vF7ZL-Bb7J8JmDm1DCR0n3lKA0F7MvEAuObqH2zQiPAvHvPbXWzMAJwfbQyZbRiT5HH_DhceT8qeFiCcGVjw6aXQ";
        string e = "AQAB";

        var rsaParameters = new RSAParameters
        {
            Modulus = Base64UrlEncoder.DecodeBytes(n),
            Exponent = Base64UrlEncoder.DecodeBytes(e)
        };

        var rsa = RSA.Create();
        rsa.ImportParameters(rsaParameters);

        var rsaKey = new RsaSecurityKey(rsa) { KeyId = "B87227CAF37461DC8E0C301D914225E0" };
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
        {
            opt.Authority = configuration["Jwt:IdentityServerUrl"];
            opt.Audience = configuration["Jwt:Audience"];
            opt.RequireHttpsMetadata = false;

            opt.TokenValidationParameters = new TokenValidationParameters
            {
                RequireSignedTokens = true,
                ValidIssuer = "http://localhost:5001",
                ValidAudience = "ResourceOrder",
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = rsaKey,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromMinutes(1)
            };

            opt.Events = new JwtBearerEvents
            {
                OnAuthenticationFailed = ctx =>
                {
                    Console.WriteLine("Authentication failed: " + ctx.Exception.Message);
                    return Task.CompletedTask;
                },
                OnTokenValidated = ctx =>
                {
                    return Task.CompletedTask;
                }
            };
        });

        #endregion

        #region DB Settings

        services.AddDbContext<OrderContext>();

        #endregion

        #region Repository Base

        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

        #endregion

        #region Handlers

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

        #endregion

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddControllers();
        return services;
    }
}