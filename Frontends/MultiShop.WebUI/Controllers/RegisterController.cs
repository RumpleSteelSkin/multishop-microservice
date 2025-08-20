using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos.RegisterDtos;
using MultiShop.WebUI.Constant;
using MultiShop.WebUI.Hooks;

namespace MultiShop.WebUI.Controllers;

[AllowAnonymous]
public class RegisterController(JsonService jsonService) : Controller
{
    [HttpGet]
    public ActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Index(CreateRegisterDto createRegisterDto)
    {
        await jsonService.PostAsync(ApiRoutes.Registers.Register, createRegisterDto);
        return RedirectToAction("Index", "Default");
    }
}