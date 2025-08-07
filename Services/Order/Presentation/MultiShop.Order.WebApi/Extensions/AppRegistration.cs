namespace MultiShop.Order.WebApi.Extensions;

public static class AppRegistration
{
    public static WebApplication AddOrderApplicationApp(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.MapControllers();

        app.Run();
        return app;
    }
}