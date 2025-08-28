using System.Text.Json;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.Redis;

namespace MultiShop.Basket.Services;

public class BasketService(RedisService redisService) : IBasketService
{
    public async Task<BasketTotalDto?> GetBasket(string userId)
    {
        var existBasket = await redisService.GetDatabase().StringGetAsync(userId);
        return existBasket.IsNullOrEmpty ? null : JsonSerializer.Deserialize<BasketTotalDto>(existBasket!);
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

    public async Task AddBasketItem(string userId, BasketItemDto basketItemDto)
    {
        var basket = await GetBasket(userId) ?? new BasketTotalDto { UserId = userId, BasketItems = [] };
        var existingItem = basket.BasketItems!.FirstOrDefault(x => x.ProductId == basketItemDto.ProductId);
        if (existingItem is not null)
            existingItem.Quantity += basketItemDto.Quantity;
        else
            basket.BasketItems!.Add(basketItemDto);
        await SaveBasket(basket);
    }

    public async Task<bool> RemoveBasketItem(string userId, string productId)
    {
        var basket = await GetBasket(userId);
        if (basket == null) return false;
        var removed = basket.BasketItems!.RemoveAll(x => x.ProductId == productId) > 0;
        if (removed) await SaveBasket(basket);
        return removed;
    }

    public async Task<bool> UpdateBasketItemQuantity(string userId, string productId, int quantity)
    {
        var basket = await GetBasket(userId);
        var item = basket?.BasketItems?.FirstOrDefault(x => x.ProductId == productId);
        if (item == null) return false;
        if (quantity <= 0)
            basket?.BasketItems!.Remove(item);
        else
            item.Quantity = quantity;
        if (basket != null) await SaveBasket(basket);
        return true;
    }
}