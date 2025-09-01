using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers;

public class DiscountController : Controller
{
    [HttpGet]
    public PartialViewResult ConfirmDiscountCoupon()
    {
        return PartialView();
    }

    [HttpPost]
    public IActionResult ConfirmDiscountCoupon(string code)
    {
        return RedirectToAction("Index", "ShoppingCart", new { code = code });
    }
}