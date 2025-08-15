using MultiShop.Catalog.Dtos.Feature;

namespace MultiShop.Catalog.Services.FeatureServices;

public interface IFeatureService
{
    Task<ICollection<ResultFeatureDto>> GetAllAsync();
    Task<GetByIdFeatureDto> GetByIdAsync(string id);
    Task CreateAsync(CreateFeatureDto createFeatureDto);
    Task UpdateAsync(UpdateFeatureDto updateFeatureDto);
    Task DeleteAsync(string id);
}

