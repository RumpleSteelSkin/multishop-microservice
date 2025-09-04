using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CargoDtos.CargoCompanyDtos;
using MultiShop.WebUI.Constant;
using MultiShop.WebUI.Hooks;

namespace MultiShop.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]")]
public class CargosController(JsonService jsonService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View(await jsonService.GetAllAsync<GetAllCargoCompanyDto>(ApiRoutes.CargoCompanies.GetAll));
    }
    [HttpGet]
    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(CreateCargoCompanyDto category)
    {
        await jsonService.PostAsync(ApiRoutes.CargoCompanies.Create, category);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Update(string id)
    {
        return View(await jsonService.GetByIdAsync<UpdateCargoCompanyDto>(ApiRoutes.CargoCompanies.GetById, id));
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> Update(UpdateCargoCompanyDto category)
    {
        await jsonService.UpdateAsync(ApiRoutes.CargoCompanies.Update, category);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await jsonService.DeleteAsync(ApiRoutes.CargoCompanies.Delete, id);
        return RedirectToAction(nameof(Index));
    }
}