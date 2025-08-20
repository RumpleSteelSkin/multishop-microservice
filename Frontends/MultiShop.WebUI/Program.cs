using Microsoft.Extensions.DependencyInjection.Extensions;
using MultiShop.WebUI.Hooks;
using MultiShop.WebUI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

#region Service Registrations
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddScoped<JsonService>();

builder.Services.AddAuthentication("cookie")
    .AddCookie("cookie", options => 
    { 
        options.LoginPath = "/Login/Index"; 
    });
#endregion

var app = builder.Build();

#region Exception & Security
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
#endregion

#region Middleware Pipeline
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<VisitorTokenMiddleware>();
#endregion

#region Endpoint Mappings
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ShoppingCart}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);
#endregion

app.Run();