using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.OfferDiscount;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.OfferDiscountServices;

public class OfferDiscountService(IMapper mapper, IDatabaseSettings settings, IMongoClient client) : IOfferDiscountService
{
    private readonly IMongoCollection<OfferDiscount> _collection = client.GetDatabase(settings.DatabaseName)
        .GetCollection<OfferDiscount>(settings.OfferDiscountCollectionName);

    public async Task<ICollection<ResultOfferDiscountDto>> GetAllAsync()
    {
        return mapper.Map<ICollection<ResultOfferDiscountDto>>(await _collection.Find(_ => true).ToListAsync());
    }

    public async Task<GetByIdOfferDiscountDto> GetByIdAsync(string id)
    {
        return mapper.Map<GetByIdOfferDiscountDto>(await _collection.Find(c => c.Id == id).FirstOrDefaultAsync());
    }

    public async Task CreateAsync(CreateOfferDiscountDto createOfferDiscountDto)
    {
        await _collection.InsertOneAsync(mapper.Map<OfferDiscount>(createOfferDiscountDto));
    }

    public async Task UpdateAsync(UpdateOfferDiscountDto updateOfferDiscountDto)
    {
        await _collection.FindOneAndReplaceAsync(x => x.Id == updateOfferDiscountDto.Id,
            mapper.Map<OfferDiscount>(updateOfferDiscountDto));
    }

    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(x => x.Id == id);
    }
}