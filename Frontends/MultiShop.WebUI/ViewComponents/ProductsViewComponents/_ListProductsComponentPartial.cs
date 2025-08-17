using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Constant;
using MultiShop.WebUI.Hooks;

namespace MultiShop.WebUI.ViewComponents.ProductsViewComponents;

public class _ListProductsComponentPartial(JsonService jsonService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(string id)
    {
        return View(await jsonService.GetAllAsync<ResultProductsWithCategoryDto>($"{ApiRoutes.Products.GetAllWithCategoryByCategoryId}/{id}"));
    }
}