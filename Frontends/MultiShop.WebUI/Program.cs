using Microsoft.Extensions.DependencyInjection.Extensions;
using MultiShop.WebUI.Filters;
using MultiShop.WebUI.Hooks;
using MultiShop.WebUI.Hubs;
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
        options.AccessDeniedPath = "/Login/Index";
        options.LogoutPath = "/Login/Index";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
        options.SlidingExpiration = true;
    });

#endregion

builder.Services.AddControllersWithViews(options => { options.Filters.Add<RedirectOnUnauthorizedFilter>(); });

#region SignalR Services

builder.Services.AddSignalR();

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
app.UseMiddleware<RedirectUnauthorizedMiddleware>();

#endregion

#region Endpoint Mappings

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

#endregion

app.MapHub<SignalRHub>("/signalrhub");

app.Run();