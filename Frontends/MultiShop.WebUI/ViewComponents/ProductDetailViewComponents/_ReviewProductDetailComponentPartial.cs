using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using MultiShop.WebUI.Constant;
using MultiShop.WebUI.Hooks;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents;

public class _ReviewProductDetailComponentPartial(JsonService jsonService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(string id)
    {
        return View(await jsonService.GetAllByIdAsync<ResultCommentDto>(ApiRoutes.Comments.GetAllByProductId, id));
    }
}