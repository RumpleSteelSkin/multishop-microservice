using Microsoft.AspNetCore.Authentication.JwtBearer;
using MultiShop.Comment.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CommentContext>();
builder.Services.AddControllers();

#region JWT Settings

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["Jwt:IdentityServerUrl"];
    opt.Audience = builder.Configuration["Jwt:Audience"];
    opt.RequireHttpsMetadata = false;
});

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("CommentRead", policy =>
    {
        policy.RequireAssertion(context =>
            context.User.HasClaim("scope", "CommentReadPermission") ||
            context.User.HasClaim("scope", "CommentFullPermission") ||
            context.User.HasClaim("scope", "CommentHalfPermission"));
    }).AddPolicy("CommentHalf", policy =>
    {
        policy.RequireAssertion(context =>
            context.User.HasClaim("scope", "CommentHalfPermission") ||
            context.User.HasClaim("scope", "CommentFullPermission"));
    })
    .AddPolicy("CommentWrite", policy => { policy.RequireClaim("scope", "CommentFullPermission"); });

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