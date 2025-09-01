using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.User.Controllers;

[Area("User")]
public class MessageController : Controller
{
    public ActionResult Index()
    {
        return View();
    }
}