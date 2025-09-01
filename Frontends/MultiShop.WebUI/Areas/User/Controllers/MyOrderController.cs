using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.User.Controllers;

[Area("User")]
public class MyOrderController : Controller
{
    public ActionResult MyOrderList()
    {
        return View();
    }
}