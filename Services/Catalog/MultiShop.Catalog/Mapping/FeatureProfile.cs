using AutoMapper;
using MultiShop.Catalog.Dtos.Feature;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Mapping;

public class FeatureProfile : Profile
{
    public FeatureProfile()
    {
        CreateMap<Feature, ResultFeatureDto>();
        CreateMap<Feature, GetByIdFeatureDto>();
        CreateMap<CreateFeatureDto, Feature>();
        CreateMap<UpdateFeatureDto, Feature>();
    }
}