using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Constant;
using MultiShop.WebUI.Hooks;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class StatisticsController(JsonService jsonService) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}