using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.About;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.AboutServices;

public class AboutService(IMapper mapper, IDatabaseSettings settings, IMongoClient client) : IAboutService
{
    private readonly IMongoCollection<About> _collection = client.GetDatabase(settings.DatabaseName)
        .GetCollection<About>(settings.AboutCollectionName);

    public async Task<ICollection<ResultAboutDto>> GetAllAsync()
    {
        return mapper.Map<ICollection<ResultAboutDto>>(await _collection.Find(_ => true).ToListAsync());
    }

    public async Task<GetByIdAboutDto> GetByIdAsync(string id)
    {
        return mapper.Map<GetByIdAboutDto>(await _collection.Find(c => c.Id == id).FirstOrDefaultAsync());
    }

    public async Task CreateAsync(CreateAboutDto createAboutDto)
    {
        await _collection.InsertOneAsync(mapper.Map<About>(createAboutDto));
    }

    public async Task UpdateAsync(UpdateAboutDto updateAboutDto)
    {
        await _collection.FindOneAndReplaceAsync(x => x.Id == updateAboutDto.Id,
            mapper.Map<About>(updateAboutDto));
    }

    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(x => x.Id == id);
    }
}