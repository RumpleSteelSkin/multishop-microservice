using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.LoginServices;
using MultiShop.Basket.Services;

namespace MultiShop.Basket.Controller;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class BasketsController(IBasketService basketService, ILoginService loginService) : ControllerBase
{
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await basketService.GetBasket(loginService.GetUserId));
    }

    [HttpPost("SaveMyBasket")]
    public async Task<IActionResult> SaveMyBasket([FromBody] BasketTotalDto basketTotalDto)
    {
        basketTotalDto.UserId = loginService.GetUserId;
        await basketService.SaveBasket(basketTotalDto);
        return Ok("Basket saved");
    }

    [HttpDelete("DeleteMyBasket")]
    public async Task<IActionResult> DeleteMyBasket()
    {
        await basketService.DeleteBasket(loginService.GetUserId);
        return Ok("Basket deleted");
    }

    [HttpPost("AddBasketItem")]
    public async Task<IActionResult> AddBasketItem([FromBody] BasketItemDto basketItemDto)
    {
        await basketService.AddBasketItem(loginService.GetUserId, basketItemDto);
        return Ok("Basket item added");
    }

    [HttpDelete("RemoveBasketItem/{productId}")]
    public async Task<IActionResult> RemoveBasketItem(string productId)
    {
        await basketService.RemoveBasketItem(loginService.GetUserId, productId);
        return Ok("Basket item removed");
    }

    [HttpPost("UpdateQuantity/{productId}/{quantity:int}")]
    public async Task<IActionResult> UpdateQuantity(string productId, int quantity)
    {
        var updated = await basketService.UpdateBasketItemQuantity(loginService.GetUserId, productId, quantity);
        return updated
            ? Ok("Quantity updated")
            : NotFound("Product not found in basket");
    }
}