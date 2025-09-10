using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers;

public class InformationController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    
}