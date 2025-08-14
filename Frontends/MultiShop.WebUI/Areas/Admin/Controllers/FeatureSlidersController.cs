using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using MultiShop.WebUI.Constant;
using MultiShop.WebUI.Hooks;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class FeatureSlidersController(JsonService jsonService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await jsonService.GetAllAsync<ResultFeatureSliderDto>(ApiRoutes.FeatureSliders.GetAll));
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateFeatureSliderDto featureSlider)
        {
            await jsonService.PostAsync(ApiRoutes.FeatureSliders.Create, featureSlider);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Update(string id)
        {
            return View(await jsonService.GetByIdAsync<UpdateFeatureSliderDto>(ApiRoutes.FeatureSliders.GetById, id));
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(UpdateFeatureSliderDto featureSlider)
        {
            await jsonService.UpdateAsync(ApiRoutes.FeatureSliders.Update, featureSlider);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await jsonService.DeleteAsync(ApiRoutes.FeatureSliders.Delete, id);
            return RedirectToAction(nameof(Index));
        }
    }
}