using MultiShop.Catalog.Dtos.Brand;

namespace MultiShop.Catalog.Services.BrandServices;

public interface IBrandService
{
    Task<ICollection<ResultBrandDto>> GetAllAsync();
    Task<GetByIdBrandDto> GetByIdAsync(string id);
    Task CreateAsync(CreateBrandDto createBrandDto);
    Task UpdateAsync(UpdateBrandDto updateBrandDto);
    Task DeleteAsync(string id);
}

