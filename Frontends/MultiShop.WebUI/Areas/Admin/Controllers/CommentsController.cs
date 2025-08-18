using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.DtoLayer.CommentDtos;
using MultiShop.WebUI.Constant;
using MultiShop.WebUI.Hooks;

namespace MultiShop.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]")]
public class CommentsController(JsonService jsonService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View(await jsonService.GetAllAsync<ResultCommentDto>(ApiRoutes.Comments.GetAll));
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewBag.ProductList = await jsonService.GetSelectListAsync<ResultProductDto>(ApiRoutes.Products.GetAll, x => x.Name, x => x.Id.ToString());
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCommentDto comment)
    {
        await jsonService.PostAsync(ApiRoutes.Comments.Create, comment);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Update(string id)
    {
        ViewBag.ProductList = await jsonService.GetSelectListAsync<ResultProductDto>(ApiRoutes.Products.GetAll, x => x.Name, x => x.Id.ToString());
        return View(await jsonService.GetByIdAsync<UpdateCommentDto>(ApiRoutes.Comments.GetById, id));
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> Update(UpdateCommentDto comment)
    {
        await jsonService.UpdateAsync(ApiRoutes.Comments.Update, comment);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await jsonService.DeleteAsync(ApiRoutes.Comments.Delete, id);
        return RedirectToAction(nameof(Index));
    }
}