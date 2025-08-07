using AutoMapper;
using MultiShop.Catalog.Dtos.Product;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Mapping;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ResultProductDto>();
        CreateMap<Product, GetByIdProductDto>();
        CreateMap<CreateProductDto, Product>();
        CreateMap<UpdateProductDto, Product>();
    }
}