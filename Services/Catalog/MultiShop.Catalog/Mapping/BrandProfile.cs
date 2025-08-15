using AutoMapper;
using MultiShop.Catalog.Dtos.Brand;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Mapping;

public class BrandProfile : Profile
{
    public BrandProfile()
    {
        CreateMap<Brand, ResultBrandDto>();
        CreateMap<Brand, GetByIdBrandDto>();
        CreateMap<CreateBrandDto, Brand>();
        CreateMap<UpdateBrandDto, Brand>();
    }
}