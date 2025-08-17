using System.Linq.Expressions;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.Product;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Services.ProductServices;

public interface IProductService
{
    Task<ICollection<ResultProductDto>> GetAllAsync();
    Task<ICollection<ResultProductDto>> GetAllAsync(Expression<Func<Product, bool>> predicate);
    Task<ICollection<ResultProductsWithCategoryDto>> GetAllWithCategoryAsync();
    Task<ICollection<ResultProductsWithCategoryDto>> GetAllWithCategoryByCategoryIdAsync(string id);
    Task<GetByIdProductDto> GetByIdAsync(string id);
    Task CreateAsync(CreateProductDto createProductDto);
    Task UpdateAsync(UpdateProductDto updateProductDto);
    Task DeleteAsync(string id);
}