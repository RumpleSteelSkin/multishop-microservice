using MultiShop.Catalog.Dtos.OfferDiscount;

namespace MultiShop.Catalog.Services.OfferDiscountServices;

public interface IOfferDiscountService
{
    Task<ICollection<ResultOfferDiscountDto>> GetAllAsync();
    Task<GetByIdOfferDiscountDto> GetByIdAsync(string id);
    Task CreateAsync(CreateOfferDiscountDto createOfferDiscountDto);
    Task UpdateAsync(UpdateOfferDiscountDto updateOfferDiscountDto);
    Task DeleteAsync(string id);
}

