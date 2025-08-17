using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Constant;
using MultiShop.WebUI.Hooks;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents;

public class _DescriptionProductDetailComponentPartial(JsonService jsonService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(string id)
    {
        return View(await jsonService.GetAsync<ResultProductDto>($"{ApiRoutes.Products.GetById}/{id}"));
    }
}