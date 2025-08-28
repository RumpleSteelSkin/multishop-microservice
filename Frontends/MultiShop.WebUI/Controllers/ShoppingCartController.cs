using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BasketDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Constant;
using MultiShop.WebUI.Hooks;

namespace MultiShop.WebUI.Controllers
{
    public class ShoppingCartController(JsonService jsonService) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
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
}