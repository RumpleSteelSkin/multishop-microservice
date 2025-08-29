using Microsoft.AspNetCore.Authentication.JwtBearer;
using MultiShop.Discount.Context;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Extensions;

public static class ServiceRegistration
{
    public static IServiceCollection AddDiscountServices(this IServiceCollection services, IConfiguration configuration)
    {
        #region JWT Settings

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
        {
            opt.Authority = configuration["Jwt:IdentityServerUrl"];
            opt.Audience = configuration["Jwt:Audience"];
            opt.RequireHttpsMetadata = false;
        });
        services.AddAuthorizationBuilder()
            .AddPolicy("DiscountRead", policy =>
            {
                policy.RequireAssertion(context =>
                    context.User.HasClaim("scope", "DiscountReadPermission") ||
                    context.User.HasClaim("scope", "DiscountFullPermission") ||
                    context.User.HasClaim("scope", "DiscountHalfPermission"));
            }).AddPolicy("DiscountHalf", policy =>
            {
                policy.RequireAssertion(context =>
                    context.User.HasClaim("scope", "DiscountHalfPermission") ||
                    context.User.HasClaim("scope", "DiscountFullPermission"));
            })
            .AddPolicy("DiscountWrite", policy => { policy.RequireClaim("scope", "DiscountFullPermission"); });

        #endregion

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