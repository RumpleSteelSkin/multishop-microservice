using AutoMapper;
using MultiShop.Catalog.Dtos.FeatureSlider;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Mapping;

public class FeatureSliderProfile : Profile
{
    public FeatureSliderProfile()
    {
        CreateMap<FeatureSlider, ResultFeatureSliderDto>();
        CreateMap<FeatureSlider, GetByIdFeatureSliderDto>();
        CreateMap<CreateFeatureSliderDto, FeatureSlider>();
        CreateMap<UpdateFeatureSliderDto, FeatureSlider>();
    }
}