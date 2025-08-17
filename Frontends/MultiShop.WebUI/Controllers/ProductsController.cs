using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        public ActionResult Index(string id)
        {
            ViewBag.CId = id;
            return View();
        }

        public ActionResult ProductDetail(string id)
        {
            ViewBag.PId = id;
            return View();
        }
    }
}