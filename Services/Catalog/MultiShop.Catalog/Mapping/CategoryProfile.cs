using AutoMapper;
using MultiShop.Catalog.Dtos.Category;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Mapping;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, ResultCategoryDto>();
        CreateMap<Category, GetByIdCategoryDto>();
        CreateMap<CreateCategoryDto, Category>();
        CreateMap<UpdateCategoryDto, Category>();
    }
}