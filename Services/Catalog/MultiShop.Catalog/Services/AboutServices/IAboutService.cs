using MultiShop.Catalog.Dtos.About;

namespace MultiShop.Catalog.Services.AboutServices;

public interface IAboutService
{
    Task<ICollection<ResultAboutDto>> GetAllAsync();
    Task<GetByIdAboutDto> GetByIdAsync(string id);
    Task CreateAsync(CreateAboutDto createAboutDto);
    Task UpdateAsync(UpdateAboutDto updateAboutDto);
    Task DeleteAsync(string id);
}

