using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using MultiShop.WebUI.Constant;
using MultiShop.WebUI.Hooks;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents;

public class _OfferDiscountDefaultComponentPartial(JsonService jsonService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View(await jsonService.GetAllAsync<ResultOfferDiscountDto>(ApiRoutes.OfferDiscounts.GetAll));
    }
}