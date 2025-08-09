using Microsoft.AspNetCore.Mvc;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.LoginServices;
using MultiShop.Basket.Services;

namespace MultiShop.Basket.Controller;

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
    public async Task<IActionResult> SaveMyBasket(BasketTotalDto basketTotalDto)
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
}