using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MultiShop.WebUI.Filters;

public class RedirectOnUnauthorizedFilter : IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (context.HttpContext.Response.StatusCode == StatusCodes.Status401Unauthorized)
        {
            context.Result = new RedirectToActionResult("Login", "Account", null);
        }
    }
}