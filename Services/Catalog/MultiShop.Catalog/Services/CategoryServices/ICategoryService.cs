using MultiShop.Catalog.Dtos.Category;

namespace MultiShop.Catalog.Services.CategoryServices;

public interface ICategoryService
{
    Task<ICollection<ResultCategoryDto>> GetAllAsync();
    Task<GetByIdCategoryDto> GetByIdAsync(string id);
    Task CreateAsync(CreateCategoryDto createCategoryDto);
    Task UpdateAsync(UpdateCategoryDto updateCategoryDto);
    Task DeleteAsync(string id);
}

