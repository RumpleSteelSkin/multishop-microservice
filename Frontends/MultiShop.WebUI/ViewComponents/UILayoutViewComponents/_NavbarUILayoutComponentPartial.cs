using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Constant;
using MultiShop.WebUI.Hooks;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents;

public class _NavbarUILayoutComponentPartial(JsonService jsonService):ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View(await jsonService.GetAllAsync<ResultCategoryDto>(ApiRoutes.Categories.GetAll));
    }
}