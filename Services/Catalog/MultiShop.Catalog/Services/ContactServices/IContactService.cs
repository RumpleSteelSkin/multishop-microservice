using MultiShop.Catalog.Dtos.Contact;

namespace MultiShop.Catalog.Services.ContactServices;

public interface IContactService
{
    Task<ICollection<ResultContactDto>> GetAllAsync();
    Task<GetByIdContactDto> GetByIdAsync(string id);
    Task CreateAsync(CreateContactDto createContactDto);
    Task UpdateAsync(UpdateContactDto updateContactDto);
    Task DeleteAsync(string id);
}

