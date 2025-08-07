using AutoMapper;
using MultiShop.Catalog.Dtos.ProductDetail;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Mapping;

public class ProductDetailProfile : Profile
{
    public ProductDetailProfile()
    {
        CreateMap<ProductDetail, ResultProductDetailDto>();
        CreateMap<ProductDetail, GetByIdProductDetailDto>();
        CreateMap<CreateProductDetailDto, ProductDetail>();
        CreateMap<UpdateProductDetailDto, ProductDetail>();
    }
}