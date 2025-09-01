using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers;

public class UILayoutController : Controller
{
    public ActionResult _UILayout()
    {
        return View();
    }

}