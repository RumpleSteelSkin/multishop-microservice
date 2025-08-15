using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.SpecialOffer;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.SpecialOfferServices;

public class SpecialOfferService(IMapper mapper, IDatabaseSettings settings, IMongoClient client) : ISpecialOfferService
{
    private readonly IMongoCollection<SpecialOffer> _collection = client.GetDatabase(settings.DatabaseName)
        .GetCollection<SpecialOffer>(settings.SpecialOfferCollectionName);

    public async Task<ICollection<ResultSpecialOfferDto>> GetAllAsync()
    {
        return mapper.Map<ICollection<ResultSpecialOfferDto>>(await _collection.Find(_ => true).ToListAsync());
    }

    public async Task<GetByIdSpecialOfferDto> GetByIdAsync(string id)
    {
        return mapper.Map<GetByIdSpecialOfferDto>(await _collection.Find(c => c.Id == id).FirstOrDefaultAsync());
    }

    public async Task CreateAsync(CreateSpecialOfferDto createSpecialOfferDto)
    {
        await _collection.InsertOneAsync(mapper.Map<SpecialOffer>(createSpecialOfferDto));
    }

    public async Task UpdateAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
    {
        await _collection.FindOneAndReplaceAsync(x => x.Id == updateSpecialOfferDto.Id,
            mapper.Map<SpecialOffer>(updateSpecialOfferDto));
    }

    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(x => x.Id == id);
    }
}