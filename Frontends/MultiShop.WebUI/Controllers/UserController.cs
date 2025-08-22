using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos.UserDtos;
using MultiShop.WebUI.Constant;
using MultiShop.WebUI.Hooks;

namespace MultiShop.WebUI.Controllers
{
    public class UserController(JsonService jsonService) : Controller
    {
        public async Task<ActionResult> Index()
        {
            return View(await jsonService.GetAsync<ResultUserDto>(ApiRoutes.Users.GetUserInfo));
        }

    }
}
