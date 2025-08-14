using MultiShop.Catalog.Dtos.Product;

namespace MultiShop.Catalog.Services.ProductServices;

public interface IProductService
{
    Task<ICollection<ResultProductDto>> GetAllAsync();
    Task<ICollection<ResultProductsWithCategoryDto>> GetAllWithCategoryAsync();
    Task<GetByIdProductDto> GetByIdAsync(string id);
    Task CreateAsync(CreateProductDto createProductDto);
    Task UpdateAsync(UpdateProductDto updateProductDto);
    Task DeleteAsync(string id);
}