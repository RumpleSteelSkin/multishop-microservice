using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using MultiShop.WebUI.Constant;
using MultiShop.WebUI.Hooks;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class BrandsController(JsonService jsonService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await jsonService.GetAllAsync<ResultBrandDto>(ApiRoutes.Brands.GetAll));
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateBrandDto brand)
        {
            await jsonService.PostAsync(ApiRoutes.Brands.Create, brand);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Update(string id)
        {
            return View(await jsonService.GetByIdAsync<UpdateBrandDto>(ApiRoutes.Brands.GetById, id));
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(UpdateBrandDto brand)
        {
            await jsonService.UpdateAsync(ApiRoutes.Brands.Update, brand);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await jsonService.DeleteAsync(ApiRoutes.Brands.Delete, id);
            return RedirectToAction(nameof(Index));
        }
    }
}