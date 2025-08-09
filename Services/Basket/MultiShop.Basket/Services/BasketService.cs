using System.Text.Json;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.Redis;

namespace MultiShop.Basket.Services;

public class BasketService(RedisService redisService) : IBasketService
{
    public async Task<BasketTotalDto?> GetBasket(string userId)
    {
        var existBasket = await redisService.GetDatabase().StringGetAsync(userId);
        return JsonSerializer.Deserialize<BasketTotalDto>(existBasket);
    }

    public async Task SaveBasket(BasketTotalDto basketTotalDto)
    {
        await redisService.GetDatabase()
            .StringSetAsync(basketTotalDto.UserId, JsonSerializer.Serialize(basketTotalDto));
    }

    public async Task DeleteBasket(string userId)
    {
        await redisService.GetDatabase().KeyDeleteAsync(userId);
    }
}