using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.Category;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.CategoryServices;

public class CategoryService(IMapper mapper, IDatabaseSettings settings, IMongoClient client) : ICategoryService
{
    private readonly IMongoCollection<Category> _collection = client.GetDatabase(settings.DatabaseName)
        .GetCollection<Category>(settings.CategoryCollectionName);

    public async Task<ICollection<ResultCategoryDto>> GetAllAsync()
    {
        return mapper.Map<ICollection<ResultCategoryDto>>(await _collection.Find(_ => true).ToListAsync());
    }

    public async Task<GetByIdCategoryDto> GetByIdAsync(string id)
    {
        return mapper.Map<GetByIdCategoryDto>(await _collection.Find(c => c.Id == id).FirstOrDefaultAsync());
    }

    public async Task CreateAsync(CreateCategoryDto createCategoryDto)
    {
        await _collection.InsertOneAsync(mapper.Map<Category>(createCategoryDto));
    }

    public async Task UpdateAsync(UpdateCategoryDto updateCategoryDto)
    {
        await _collection.FindOneAndReplaceAsync(x => x.Id == updateCategoryDto.Id,
            mapper.Map<Category>(updateCategoryDto));
    }

    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(x => x.Id == id);
    }
}