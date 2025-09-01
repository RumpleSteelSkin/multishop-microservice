using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using MultiShop.WebUI.Constant;
using MultiShop.WebUI.Hooks;

namespace MultiShop.WebUI.Controllers;

public class ProductsController(JsonService jsonService) : Controller
{
    public ActionResult Index(string id)
    {
        ViewBag.CId = id;
        return View();
    }

    public ActionResult ProductDetail(string id)
    {
        ViewBag.PId = id;
        return View();
    }

    [HttpGet]
    public PartialViewResult CreateComment()
    {
        return PartialView();
    }

    [HttpPost]
    public async Task<IActionResult> CreateComment(CreateCommentDto comment)
    {
        comment.CreatedDate = DateTime.Now;
        comment.ImageUrl = "https://thispersondoesnotexist.com/";
        comment.Status = false;
        await jsonService.PostAsync(ApiRoutes.Comments.Create, comment);
        return RedirectToAction("Index", "Default");
    }
}