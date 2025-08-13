using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Constant;
using MultiShop.WebUI.Hooks;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class CategoriesController(JsonService jsonService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await jsonService.GetAllAsync<ResultCategoryDto>(ApiRoutes.Categories.GetAll));
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto category)
        {
            await jsonService.PostAsync(ApiRoutes.Categories.Create, category);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Update(string id)
        {
            return View(await jsonService.GetByIdAsync<UpdateCategoryDto>(ApiRoutes.Categories.GetById, id));
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(UpdateCategoryDto category)
        {
            await jsonService.UpdateAsync(ApiRoutes.Categories.Update, category);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await jsonService.DeleteAsync(ApiRoutes.Categories.Delete, id);
            return RedirectToAction(nameof(Index));
        }
    }
}