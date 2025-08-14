using AutoMapper;
using MultiShop.Catalog.Dtos.Product;
using MultiShop.Catalog.Entities;
using ZstdSharp.Unsafe;

namespace MultiShop.Catalog.Mapping;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ResultProductDto>();
        CreateMap<Product, GetByIdProductDto>();
        CreateMap<CreateProductDto, Product>();
        CreateMap<UpdateProductDto, Product>();
        CreateMap<Product, ResultProductsWithCategoryDto>();
    }
}