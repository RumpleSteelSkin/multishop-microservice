using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.Product;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices;

public class ProductService(IMapper mapper, IDatabaseSettings settings, IMongoClient client) : IProductService
{
    private readonly IMongoCollection<Product> _collection = client.GetDatabase(settings.DatabaseName)
        .GetCollection<Product>(settings.ProductCollectionName);

    public async Task<ICollection<ResultProductDto>> GetAllAsync()
    {
        return mapper.Map<ICollection<ResultProductDto>>(await _collection.Find(_ => true).ToListAsync());
    }

    public async Task<GetByIdProductDto> GetByIdAsync(string id)
    {
        return mapper.Map<GetByIdProductDto>(await _collection.Find(c => c.Id == id).FirstOrDefaultAsync());
    }

    public async Task CreateAsync(CreateProductDto createProductDto)
    {
        await _collection.InsertOneAsync(mapper.Map<Product>(createProductDto));
    }

    public async Task UpdateAsync(UpdateProductDto updateProductDto)
    {
        await _collection.FindOneAndReplaceAsync(x => x.Id == updateProductDto.Id,
            mapper.Map<Product>(updateProductDto));
    }

    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(x => x.Id == id);
    }
}