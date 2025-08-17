using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using MultiShop.WebUI.Constant;
using MultiShop.WebUI.Hooks;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class AboutsController(JsonService jsonService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await jsonService.GetAllAsync<ResultAboutDto>(ApiRoutes.Abouts.GetAll));
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateAboutDto about)
        {
            await jsonService.PostAsync(ApiRoutes.Abouts.Create, about);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Update(string id)
        {
            return View(await jsonService.GetByIdAsync<UpdateAboutDto>(ApiRoutes.Abouts.GetById, id));
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(UpdateAboutDto about)
        {
            await jsonService.UpdateAsync(ApiRoutes.Abouts.Update, about);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await jsonService.DeleteAsync(ApiRoutes.Abouts.Delete, id);
            return RedirectToAction(nameof(Index));
        }
    }
}