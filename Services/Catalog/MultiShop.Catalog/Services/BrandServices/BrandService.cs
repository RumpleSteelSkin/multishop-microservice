using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.Brand;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.BrandServices;

public class BrandService(IMapper mapper, IDatabaseSettings settings, IMongoClient client) : IBrandService
{
    private readonly IMongoCollection<Brand> _collection = client.GetDatabase(settings.DatabaseName)
        .GetCollection<Brand>(settings.BrandCollectionName);

    public async Task<ICollection<ResultBrandDto>> GetAllAsync()
    {
        return mapper.Map<ICollection<ResultBrandDto>>(await _collection.Find(_ => true).ToListAsync());
    }

    public async Task<GetByIdBrandDto> GetByIdAsync(string id)
    {
        return mapper.Map<GetByIdBrandDto>(await _collection.Find(c => c.Id == id).FirstOrDefaultAsync());
    }

    public async Task CreateAsync(CreateBrandDto createBrandDto)
    {
        await _collection.InsertOneAsync(mapper.Map<Brand>(createBrandDto));
    }

    public async Task UpdateAsync(UpdateBrandDto updateBrandDto)
    {
        await _collection.FindOneAndReplaceAsync(x => x.Id == updateBrandDto.Id,
            mapper.Map<Brand>(updateBrandDto));
    }

    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(x => x.Id == id);
    }
}