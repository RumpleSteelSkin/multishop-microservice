using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using MultiShop.WebUI.Constant;
using MultiShop.WebUI.Hooks;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents;

public class _FeatureDefaultComponentPartial(JsonService jsonService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View(await jsonService.GetAllAsync<ResultFeatureDto>(ApiRoutes.Features.GetAll));
    }
}