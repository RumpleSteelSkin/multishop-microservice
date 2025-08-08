namespace MultiShop.Discount.Extensions;

public static class AppRegistration
{
    public static WebApplication AddDiscountApp(this WebApplication app)
    {
        #region Middleware Pipeline

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        #endregion

        #region Endpoint Configuration

        app.MapControllers();
        app.UseAuthentication();
        app.UseAuthorization();

        #endregion

        app.Run();
        return app;
    }
}