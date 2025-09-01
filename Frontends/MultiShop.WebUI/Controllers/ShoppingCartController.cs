using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BasketDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.DtoLayer.DiscountDtos;
using MultiShop.WebUI.Constant;
using MultiShop.WebUI.Hooks;

namespace MultiShop.WebUI.Controllers;

public class ShoppingCartController(JsonService jsonService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index(string code)
    {
        ViewBag.totalPrice = (await jsonService.GetAsync<BasketTotalDto>(ApiRoutes.Baskets.GetAll))!.TotalPrice;
        ViewBag.taxAmount = (decimal)ViewBag.totalPrice * (decimal)0.15;
        ViewBag.totalWithTax = (decimal)ViewBag.totalPrice + (decimal)ViewBag.taxAmount;
        var discount =
            await jsonService.GetByIdAsync<ResultCouponDto>(ApiRoutes.Discounts.GetCodeDetailByCode, code);
        if (discount is not null)
        {
            ViewBag.code = code;
            ViewBag.discountRate = discount.Rate;
            ViewBag.totalWithDiscount = (decimal)ViewBag.totalWithTax - (((decimal)discount.Rate / 100) * (decimal)ViewBag.totalWithTax);
        }
        else
        {
            ViewBag.code = "";
            ViewBag.discountRate = 0;
            ViewBag.totalWithDiscount = 0;
        }

        return View();
    }

    public async Task<ActionResult> AddBasketItem(string productId)
    {
        var product = await jsonService.GetByIdAsync<GetByIdProductDto>(ApiRoutes.Products.GetById, productId);
        if (product is not null)
        {
            await jsonService.PostAsync(ApiRoutes.Baskets.AddBasketItem, new BasketItemDto
            {
                ProductId = productId,
                Price = product.Price,
                ProductName = product.Name,
                ProductImageUrl = product.Images[0].Url,
                Quantity = 1,
            });
        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<ActionResult> RemoveBasketItem(string productId)
    {
        await jsonService.DeleteAsync(ApiRoutes.Baskets.RemoveBasketItem, productId);
        return RedirectToAction(nameof(Index));
    }

    public async Task<ActionResult> UpdateQuantity(string productId, int quantity)
    {
        await jsonService.FireAndForgetPostAsync(ApiRoutes.Baskets.UpdateQuantity, productId, quantity.ToString());
        return RedirectToAction(nameof(Index));
    }
}