using AutoMapper;
using MultiShop.Catalog.Dtos.ProductImage;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Mapping;

public class ProductImageProfile : Profile
{
    public ProductImageProfile()
    {
        CreateMap<ProductImage, ResultProductImageDto>();
        CreateMap<ProductImage, GetByIdProductImageDto>();
        CreateMap<CreateProductImageDto, ProductImage>();
        CreateMap<UpdateProductImageDto, ProductImage>();
    }
}