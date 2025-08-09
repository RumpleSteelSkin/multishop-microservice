namespace MultiShop.Basket.LoginServices;

public class LoginService(IHttpContextAccessor contextAccessor) : ILoginService
{
    public string GetUserId =>
        (((contextAccessor.HttpContext ?? throw new Exception("Context is empty")).User ??
          throw new Exception("User is empty")).FindFirst("sub") ?? throw new Exception("Sub is empty")).Value;
}