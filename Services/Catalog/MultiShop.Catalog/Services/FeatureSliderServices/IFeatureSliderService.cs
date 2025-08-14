using MultiShop.Catalog.Dtos.FeatureSlider;

namespace MultiShop.Catalog.Services.FeatureSliderServices;

public interface IFeatureSliderService
{
    Task<ICollection<ResultFeatureSliderDto>> GetAllAsync();
    Task<GetByIdFeatureSliderDto> GetByIdAsync(string id);
    Task CreateAsync(CreateFeatureSliderDto createFeatureSliderDto);
    Task UpdateAsync(UpdateFeatureSliderDto updateFeatureSliderDto);
    Task DeleteAsync(string id);
}