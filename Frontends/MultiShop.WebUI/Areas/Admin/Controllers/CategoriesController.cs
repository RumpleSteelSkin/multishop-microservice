using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Constant;
using MultiShop.WebUI.Hooks;

namespace MultiShop.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoriesController(JsonService jsonService) : Controller
{
    public async Task<ActionResult> Index()
    {
        return View(await jsonService.GetAllAsync<ResultCategoryDto>(ApiRoutes.Categories.GetAll));
    }
}