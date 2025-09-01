using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers;

public class PaymentController : Controller
{
    public ActionResult Index()
    {
        return View();
    }
}