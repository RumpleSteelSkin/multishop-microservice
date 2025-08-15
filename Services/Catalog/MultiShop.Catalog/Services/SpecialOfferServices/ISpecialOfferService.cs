using MultiShop.Catalog.Dtos.SpecialOffer;

namespace MultiShop.Catalog.Services.SpecialOfferServices;

public interface ISpecialOfferService
{
    Task<ICollection<ResultSpecialOfferDto>> GetAllAsync();
    Task<GetByIdSpecialOfferDto> GetByIdAsync(string id);
    Task CreateAsync(CreateSpecialOfferDto createSpecialOfferDto);
    Task UpdateAsync(UpdateSpecialOfferDto updateSpecialOfferDto);
    Task DeleteAsync(string id);
}

