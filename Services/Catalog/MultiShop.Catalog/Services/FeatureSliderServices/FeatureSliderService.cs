using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeatureSlider;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureSliderServices;

public class FeatureSliderService(IMapper mapper, IDatabaseSettings settings, IMongoClient client) : IFeatureSliderService
{
    private readonly IMongoCollection<FeatureSlider> _collection = client.GetDatabase(settings.DatabaseName)
        .GetCollection<FeatureSlider>(settings.FeatureSliderCollectionName);

    public async Task<ICollection<ResultFeatureSliderDto>> GetAllAsync()
    {
        return mapper.Map<ICollection<ResultFeatureSliderDto>>(await _collection.Find(_ => true).ToListAsync());
    }

    public async Task<GetByIdFeatureSliderDto> GetByIdAsync(string id)
    {
        return mapper.Map<GetByIdFeatureSliderDto>(await _collection.Find(c => c.Id == id).FirstOrDefaultAsync());
    }

    public async Task CreateAsync(CreateFeatureSliderDto createFeatureSliderDto)
    {
        await _collection.InsertOneAsync(mapper.Map<FeatureSlider>(createFeatureSliderDto));
    }

    public async Task UpdateAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
    {
        await _collection.FindOneAndReplaceAsync(x => x.Id == updateFeatureSliderDto.Id,
            mapper.Map<FeatureSlider>(updateFeatureSliderDto));
    }

    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(x => x.Id == id);
    }
}