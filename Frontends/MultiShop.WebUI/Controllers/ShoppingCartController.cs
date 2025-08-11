using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
