using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;

namespace MultiShop.DtoLayer.CatalogDtos.ProductDtos;

public class CreateProductDto : BaseProductDto
{
    public List<CreateProductImageDto> Images { get; set; } = [];
    public CreateProductDetailDto? Details { get; set; }
}