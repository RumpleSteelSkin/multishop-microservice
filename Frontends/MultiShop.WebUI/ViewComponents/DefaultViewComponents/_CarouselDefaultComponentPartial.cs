using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using MultiShop.WebUI.Constant;
using MultiShop.WebUI.Hooks;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents;

public class _CarouselDefaultComponentPartial(JsonService jsonService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View(await jsonService.GetAllAsync<ResultFeatureSliderDto>(ApiRoutes.FeatureSliders.GetAll));
    }
}