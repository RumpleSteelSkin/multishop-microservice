using MultiShop.Basket.Dtos;

namespace MultiShop.Basket.Services;

public interface IBasketService
{
    Task<BasketTotalDto?> GetBasket(string userId);
    Task SaveBasket(BasketTotalDto basketTotalDto);
    Task DeleteBasket(string userId);
    Task AddBasketItem(string userId, BasketItemDto basketItemDto);
    Task<bool> RemoveBasketItem(string userId, string productId);
    Task<bool> UpdateBasketItemQuantity(string userId, string productId, int quantity);
}