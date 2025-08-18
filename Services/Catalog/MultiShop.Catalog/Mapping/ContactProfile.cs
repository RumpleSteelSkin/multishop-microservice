using AutoMapper;
using MultiShop.Catalog.Dtos.Contact;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Mapping;

public class ContactProfile : Profile
{
    public ContactProfile()
    {
        CreateMap<Contact, ResultContactDto>();
        CreateMap<Contact, GetByIdContactDto>();
        CreateMap<CreateContactDto, Contact>();
        CreateMap<UpdateContactDto, Contact>();
    }
}