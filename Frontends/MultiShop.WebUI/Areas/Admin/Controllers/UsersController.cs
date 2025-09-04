using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CargoDtos.CargoCustomerDtos;
using MultiShop.DtoLayer.IdentityDtos.UserDtos;
using MultiShop.WebUI.Constant;
using MultiShop.WebUI.Hooks;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class UsersController(JsonService jsonService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await jsonService.GetAllAsync<ResultUserDto>(ApiRoutes.Users.GetAllUsers));
        }

        [HttpGet]
        public async Task<IActionResult> UserAddressInfo(string id)
        {
            return View(await jsonService.GetAllByIdAsync<GetAllCargoCustomerDto>(ApiRoutes.CargoCustomers.GetCargoCustomerById, id));
        }
    }
}