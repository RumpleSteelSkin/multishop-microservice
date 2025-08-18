using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.Contact;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ContactServices;

public class ContactService(IMapper mapper, IDatabaseSettings settings, IMongoClient client) : IContactService
{
    private readonly IMongoCollection<Contact> _collection = client.GetDatabase(settings.DatabaseName)
        .GetCollection<Contact>(settings.ContactCollectionName);

    public async Task<ICollection<ResultContactDto>> GetAllAsync()
    {
        return mapper.Map<ICollection<ResultContactDto>>(await _collection.Find(_ => true).ToListAsync());
    }

    public async Task<GetByIdContactDto> GetByIdAsync(string id)
    {
        return mapper.Map<GetByIdContactDto>(await _collection.Find(c => c.Id == id).FirstOrDefaultAsync());
    }

    public async Task CreateAsync(CreateContactDto createContactDto)
    {
        await _collection.InsertOneAsync(mapper.Map<Contact>(createContactDto));
    }

    public async Task UpdateAsync(UpdateContactDto updateContactDto)
    {
        await _collection.FindOneAndReplaceAsync(x => x.Id == updateContactDto.Id,
            mapper.Map<Contact>(updateContactDto));
    }

    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(x => x.Id == id);
    }
}