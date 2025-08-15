using AutoMapper;
using MultiShop.Catalog.Dtos.OfferDiscount;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Mapping;

public class OfferDiscountProfile : Profile
{
    public OfferDiscountProfile()
    {
        CreateMap<OfferDiscount, ResultOfferDiscountDto>();
        CreateMap<OfferDiscount, GetByIdOfferDiscountDto>();
        CreateMap<CreateOfferDiscountDto, OfferDiscount>();
        CreateMap<UpdateOfferDiscountDto, OfferDiscount>();
    }
}