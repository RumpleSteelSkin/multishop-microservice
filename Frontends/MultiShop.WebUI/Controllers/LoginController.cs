using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos.LoginDtos;
// using MultiShop.DtoLayer.IdentityDtos.LoginDtos;
using MultiShop.WebUI.Constant;
using MultiShop.WebUI.Hooks;
using MultiShop.WebUI.Models;

namespace MultiShop.WebUI.Controllers
{
    public class LoginController(JsonService jsonService)
        : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(CreateLoginDto createLoginDto)
        {
            var token = await jsonService.GetTokenAsync(createLoginDto.Username, createLoginDto.Password);
            if (token == null)
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View(createLoginDto);
            }

            Response.Cookies.Append("access_token", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddHours(1)
            });

            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, createLoginDto.Username!),
            };

            var identity = new ClaimsIdentity(claims, "cookie");
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync("cookie", principal);

            return RedirectToAction("Index", "Default");
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("access_token");
            return RedirectToAction("Index", "Default");
        }
    }
}