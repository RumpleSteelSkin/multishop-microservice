namespace MultiShop.Catalog.Extensions;

public static class AppRegistration
{
    public static WebApplication AddCatalogApp(this WebApplication app)
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
        #endregion

        #region Application Startup
        app.Run();
        #endregion

        return app;
    }
}