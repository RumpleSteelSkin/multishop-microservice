using System.Text;

namespace MultiShop.Order.WebApi.Middlewares;

public class JwtLoggingMiddleware(RequestDelegate next, ILogger<JwtLoggingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        logger.LogInformation("?? Request: {Method} {Path} at {Time}", 
            context.Request.Method, context.Request.Path, DateTime.Now);

        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        if (!string.IsNullOrEmpty(token))
        {
            logger.LogInformation("?? Bearer token received: {Token}", token);

            var parts = token.Split('.');
            if (parts.Length == 3)
            {
                var header = Encoding.UTF8.GetString(Convert.FromBase64String(AddPadding(parts[0])));
                var payload = Encoding.UTF8.GetString(Convert.FromBase64String(AddPadding(parts[1])));

                logger.LogInformation("?? JWT Header: {Header}", header);
                logger.LogInformation("?? JWT Payload: {Payload}", payload);
                logger.LogInformation("?? JWT Payload Length: {PayloadLength}", payload.Length);
            }
        }

        if (!context.User.Identity.IsAuthenticated)
        {
            logger.LogWarning("?? User is NOT authenticated.");
        }
        else
        {
            logger.LogInformation("?? Authenticated User: {Name}", context.User.Identity.Name ?? "(no name)");
        }

        await next(context);
    }

    private static string AddPadding(string base64)
    {
        return base64.PadRight(base64.Length + (4 - base64.Length % 4) % 4, '=');
    }
}
