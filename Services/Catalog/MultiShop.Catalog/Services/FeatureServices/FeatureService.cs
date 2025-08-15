using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.Feature;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureServices;

public class FeatureService(IMapper mapper, IDatabaseSettings settings, IMongoClient client) : IFeatureService
{
    private readonly IMongoCollection<Feature> _collection = client.GetDatabase(settings.DatabaseName)
        .GetCollection<Feature>(settings.FeatureCollectionName);

    public async Task<ICollection<ResultFeatureDto>> GetAllAsync()
    {
        return mapper.Map<ICollection<ResultFeatureDto>>(await _collection.Find(_ => true).ToListAsync());
    }

    public async Task<GetByIdFeatureDto> GetByIdAsync(string id)
    {
        return mapper.Map<GetByIdFeatureDto>(await _collection.Find(c => c.Id == id).FirstOrDefaultAsync());
    }

    public async Task CreateAsync(CreateFeatureDto createFeatureDto)
    {
        await _collection.InsertOneAsync(mapper.Map<Feature>(createFeatureDto));
    }

    public async Task UpdateAsync(UpdateFeatureDto updateFeatureDto)
    {
        await _collection.FindOneAndReplaceAsync(x => x.Id == updateFeatureDto.Id,
            mapper.Map<Feature>(updateFeatureDto));
    }

    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(x => x.Id == id);
    }
}