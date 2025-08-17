using AutoMapper;
using MultiShop.Catalog.Dtos.About;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Mapping;

public class AboutProfile : Profile
{
    public AboutProfile()
    {
        CreateMap<About, ResultAboutDto>();
        CreateMap<About, GetByIdAboutDto>();
        CreateMap<CreateAboutDto, About>();
        CreateMap<UpdateAboutDto, About>();
    }
}