using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.OrderDtos.AddressDtos;
using MultiShop.WebUI.Constant;
using MultiShop.WebUI.Hooks;

namespace MultiShop.WebUI.Controllers;

public class OrderController(JsonService jsonService) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Index(CreateAddressDto createAddressDto)
    {
        createAddressDto.UserId = jsonService.GetUserId() ?? throw new Exception("User not found");
        await jsonService.PostAsync(ApiRoutes.Addresses.Create, createAddressDto);
        return RedirectToAction("Index", "Payment");
    }
}