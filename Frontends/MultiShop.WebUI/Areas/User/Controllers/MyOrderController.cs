using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.OrderDtos.OrderingDtos;
using MultiShop.WebUI.Constant;
using MultiShop.WebUI.Hooks;

namespace MultiShop.WebUI.Areas.User.Controllers;

[Area("User")]
public class MyOrderController(JsonService jsonService) : Controller
{
    public async Task<ActionResult> MyOrderList()
    {
        return View(await jsonService.GetAllByIdAsync<ResultOrderingByUserIdDto>(
            ApiRoutes.Orderings.GetOrderingByUserId,
            jsonService.GetUserId() ?? throw new InvalidOperationException("User not found.")));
    }
}