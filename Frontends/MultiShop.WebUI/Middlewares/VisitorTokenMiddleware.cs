using MultiShop.WebUI.Constant;
using MultiShop.WebUI.Models;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Middlewares;

public class VisitorTokenMiddleware(
    RequestDelegate next,
    IHttpClientFactory httpClientFactory,
    IConfiguration configuration)
{
    public async Task InvokeAsync(HttpContext context)
    {
        var accessToken = context.Request.Cookies["access_token"];

        if (string.IsNullOrWhiteSpace(accessToken))
        {
            var client = httpClientFactory.CreateClient();

            var response = await client.PostAsync(ApiRoutes.Connect.Token,
                new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "client_id", "MultiShopVisitorId" },
                    { "client_secret", configuration["Jwt:Secret"]! },
                    { "grant_type", "client_credentials" }
                }));

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var tokenResponse = JsonConvert.DeserializeObject<TokenResponseDto>(content);

                if (!string.IsNullOrEmpty(tokenResponse?.AccessToken))
                {
                    accessToken = tokenResponse.AccessToken;
                    context.Response.Cookies.Append("access_token", accessToken,
                        new CookieOptions
                        {
                            HttpOnly = true,
                            Secure = true,
                            SameSite = SameSiteMode.Strict,
                            Expires = DateTime.UtcNow.AddSeconds(tokenResponse.ExpiresIn)
                        });
                    context.Request.Headers["Authorization"] = $"Bearer {accessToken}";
                }
            }
        }
        else
        {
            context.Request.Headers["Authorization"] = $"Bearer {accessToken}";
        }

        await next(context);
    }
}
