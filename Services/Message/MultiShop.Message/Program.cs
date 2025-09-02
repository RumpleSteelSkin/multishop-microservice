using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using MultiShop.Message.DAL.Context;
using MultiShop.Message.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MessageContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration["ConnectionStrings:DefaultConnection"]);
});

#region JWT Settings

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["Jwt:IdentityServerUrl"];
    opt.Audience = builder.Configuration["Jwt:Audience"];
    opt.RequireHttpsMetadata = false;
});

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("MessageRead", policy =>
    {
        policy.RequireAssertion(context =>
            context.User.HasClaim("scope", "MessageReadPermission") ||
            context.User.HasClaim("scope", "MessageFullPermission") ||
            context.User.HasClaim("scope", "MessageHalfPermission"));
    }).AddPolicy("MessageHalf", policy =>
    {
        policy.RequireAssertion(context =>
            context.User.HasClaim("scope", "MessageHalfPermission") ||
            context.User.HasClaim("scope", "MessageFullPermission"));
    })
    .AddPolicy("MessageWrite", policy => { policy.RequireClaim("scope", "MessageFullPermission"); });

#endregion

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IUserMessageService, UserMessageService>();
builder.Services.AddControllers();

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
