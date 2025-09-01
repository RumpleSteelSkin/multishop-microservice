using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos.LoginDtos;
using MultiShop.WebUI.Hooks;

namespace MultiShop.WebUI.Controllers;

public class LoginController(JsonService jsonService) : Controller
{
    [HttpGet]
    public ActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Index(CreateLoginDto createLoginDto)
    {
        var tokenResponse =
            await jsonService.GetTokenAsync(createLoginDto.Username!, createLoginDto.Password!);
        if (tokenResponse?.AccessToken == null)
        {
            ModelState.AddModelError("", "Invalid username or password");
            return View(createLoginDto);
        }

        Response.Cookies.Append("access_token", tokenResponse.AccessToken, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = DateTime.UtcNow.AddSeconds(tokenResponse.ExpiresIn)
        });

        if (!string.IsNullOrEmpty(tokenResponse.RefreshToken))
        {
            Response.Cookies.Append("refresh_token", tokenResponse.RefreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddDays(7)
            });
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, createLoginDto.Username!),
        };

        var identity = new ClaimsIdentity(claims, "cookie");
        var principal = new ClaimsPrincipal(identity);
        await HttpContext.SignInAsync("cookie", principal);

        return RedirectToAction("Index", "Default");
    }

    public async Task<IActionResult> Logout()
    {
        Response.Cookies.Delete("access_token");
        Response.Cookies.Delete("refresh_token");

        await HttpContext.SignOutAsync("cookie");

        return RedirectToAction("Index", "Default");
    }
}