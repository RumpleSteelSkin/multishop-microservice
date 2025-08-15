using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using MultiShop.WebUI.Constant;
using MultiShop.WebUI.Hooks;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class FeaturesController(JsonService jsonService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await jsonService.GetAllAsync<ResultFeatureDto>(ApiRoutes.Features.GetAll));
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFeatureDto feature)
        {
            await jsonService.PostAsync(ApiRoutes.Features.Create, feature);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Update(string id)
        {
            return View(await jsonService.GetByIdAsync<UpdateFeatureDto>(ApiRoutes.Features.GetById, id));
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(UpdateFeatureDto feature)
        {
            await jsonService.UpdateAsync(ApiRoutes.Features.Update, feature);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await jsonService.DeleteAsync(ApiRoutes.Features.Delete, id);
            return RedirectToAction(nameof(Index));
        }
    }
}