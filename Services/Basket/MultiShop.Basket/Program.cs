using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.IdentityModel.JsonWebTokens;
using MultiShop.Basket.LoginServices;
using MultiShop.Basket.Redis;
using MultiShop.Basket.Services;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);


#region JWT Settings

JsonWebTokenHandler.DefaultInboundClaimTypeMap.Clear();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["Jwt:IdentityServerUrl"];
    opt.Audience = builder.Configuration["Jwt:Audience"];
    opt.RequireHttpsMetadata = false;
});

#endregion

#region CRUD Services

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IBasketService, BasketService>();

#endregion

#region Redis Settings

var redisConnection = ConnectionMultiplexer.Connect(
    $"{builder.Configuration["RedisSettings:Host"]}:{builder.Configuration["RedisSettings:Port"]}");
builder.Services.AddSingleton<RedisService>(_ => new RedisService(redisConnection));
builder.Services.AddHealthChecks().AddAsyncCheck("Redis", async () =>
{
    try
    {
        await redisConnection.GetDatabase().PingAsync();
        return HealthCheckResult.Healthy();
    }
    catch
    {
        return HealthCheckResult.Unhealthy();
    }
});

#endregion

#region Other Services

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(x =>
    x.Filters.Add(new AuthorizeFilter(new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build())));

#endregion


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();