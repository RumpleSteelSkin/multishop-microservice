using AutoMapper;
using MultiShop.Catalog.Dtos.SpecialOffer;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Mapping;

public class SpecialOfferProfile : Profile
{
    public SpecialOfferProfile()
    {
        CreateMap<SpecialOffer, ResultSpecialOfferDto>();
        CreateMap<SpecialOffer, GetByIdSpecialOfferDto>();
        CreateMap<CreateSpecialOfferDto, SpecialOffer>();
        CreateMap<UpdateSpecialOfferDto, SpecialOffer>();
    }
}