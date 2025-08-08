using MultiShop.Order.WebApi.Middlewares;

namespace MultiShop.Order.WebApi.Extensions;

public static class AppRegistration
{
    public static WebApplication AddOrderWebApiApp(this WebApplication app)
    {
        #region Development Configuration
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        #endregion

        #region Middleware Pipeline
        app.UseHttpsRedirection();
        app.MapControllers();
        app.UseRouting();
        app.UseMiddleware<JwtLoggingMiddleware>();
        app.UseAuthentication();
        app.UseAuthorization();
        #endregion

        #region Application Startup
        app.Run();
        #endregion
        return app;
    }
}