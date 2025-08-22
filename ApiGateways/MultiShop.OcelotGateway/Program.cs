using Microsoft.AspNetCore.Authentication.JwtBearer;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOcelot(new ConfigurationBuilder().AddJsonFile("ocelot.json").Build());
builder.Services.AddAuthentication().AddJwtBearer("OcelotAuthenticationScheme", opt =>
{
    opt.Authority = builder.Configuration["Jwt:IdentityServerUrl"];
    opt.Audience = builder.Configuration["Jwt:Audience"];
    opt.RequireHttpsMetadata = false;
});

var app = builder.Build();

await app.UseOcelot();
app.MapGet("/", () => "Hello World!");

app.Run();