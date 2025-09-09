using System.Linq.Expressions;
using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.Product;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices;

public class ProductService(IMapper mapper, IDatabaseSettings settings, IMongoClient client) : IProductService
{
    private readonly IMongoCollection<Product> _productCollection = client.GetDatabase(settings.DatabaseName)
        .GetCollection<Product>(settings.ProductCollectionName);

    private readonly IMongoCollection<Category> _categoryCollection = client.GetDatabase(settings.DatabaseName)
        .GetCollection<Category>(settings.CategoryCollectionName);

    public async Task<ICollection<ResultProductDto>> GetAllAsync()
    {
        return mapper.Map<ICollection<ResultProductDto>>(await _productCollection.Find(_ => true).ToListAsync());
    }
    
    public async Task<long> GetCountAsync()
    {
        return await _productCollection.CountDocumentsAsync(FilterDefinition<Product>.Empty);
    }


    public async Task<ICollection<ResultProductDto>> GetAllAsync(Expression<Func<Product, bool>> predicate)
    {
        return mapper.Map<ICollection<ResultProductDto>>(await _productCollection.Find(predicate).ToListAsync());
    }

    public async Task<ICollection<ResultProductsWithCategoryDto>> GetAllWithCategoryAsync()
    {
        var values = await _productCollection.Find(_ => true).ToListAsync();
        foreach (var item in values)
            item.Category = _categoryCollection.Find(c => c.Id == item.CategoryId).FirstOrDefault();
        return mapper.Map<ICollection<ResultProductsWithCategoryDto>>(values);
    }

    public async Task<ICollection<ResultProductsWithCategoryDto>> GetAllWithCategoryByCategoryIdAsync(string id)
    {
        var values = await _productCollection.Find(x => x.CategoryId == id).ToListAsync();
        foreach (var item in values)
            item.Category = _categoryCollection.Find(c => c.Id == item.CategoryId).FirstOrDefault();
        return mapper.Map<ICollection<ResultProductsWithCategoryDto>>(values);
    }

    public async Task<GetByIdProductDto> GetByIdAsync(string id)
    {
        return mapper.Map<GetByIdProductDto>(await _productCollection.Find(c => c.Id == id).FirstOrDefaultAsync());
    }

    public async Task CreateAsync(CreateProductDto createProductDto)
    {
        await _productCollection.InsertOneAsync(mapper.Map<Product>(createProductDto));
    }

    public async Task UpdateAsync(UpdateProductDto updateProductDto)
    {
        await _productCollection.FindOneAndReplaceAsync(x => x.Id == updateProductDto.Id,
            mapper.Map<Product>(updateProductDto));
    }

    public async Task DeleteAsync(string id)
    {
        await _productCollection.DeleteOneAsync(x => x.Id == id);
    }
}