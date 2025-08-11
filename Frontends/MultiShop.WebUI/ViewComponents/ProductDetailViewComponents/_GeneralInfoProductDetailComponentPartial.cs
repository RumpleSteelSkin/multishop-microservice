using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents;

public class _GeneralInfoProductDetailComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}