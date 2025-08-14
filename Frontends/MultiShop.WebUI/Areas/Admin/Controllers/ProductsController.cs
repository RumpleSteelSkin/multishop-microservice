using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Constant;
using MultiShop.WebUI.Hooks;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class ProductsController(JsonService jsonService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await jsonService.GetAllAsync<ResultProductsWithCategoryDto>(ApiRoutes.Products.GetAllWithCategory));
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryList =
                await jsonService.GetSelectListAsync<ResultCategoryDto>(ApiRoutes.Categories.GetAll, x => x.Name,
                    x => x.Id.ToString());
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto product)
        {
            await jsonService.PostAsync(ApiRoutes.Products.Create, product);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Update(string id)
        {
            ViewBag.CategoryList =
                await jsonService.GetSelectListAsync<ResultCategoryDto>(ApiRoutes.Categories.GetAll, x => x.Name,
                    x => x.Id.ToString());
            return View(await jsonService.GetByIdAsync<UpdateProductDto>(ApiRoutes.Products.GetById, id));
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(UpdateProductDto product)
        {
            await jsonService.UpdateAsync(ApiRoutes.Products.Update, product);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await jsonService.DeleteAsync(ApiRoutes.Products.Delete, id);
            return RedirectToAction(nameof(Index));
        }
    }
}