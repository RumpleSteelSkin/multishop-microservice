namespace MultiShop.WebUI.Middlewares;

public class RedirectUnauthorizedMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        await next(context);

        if (context.Response.StatusCode is StatusCodes.Status401Unauthorized or StatusCodes.Status403Forbidden)
        {
            context.Response.Redirect("/Login/Index");
        }
    }
}