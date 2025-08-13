using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;

namespace MultiShop.DtoLayer.CatalogDtos.ProductDtos;

public class UpdateProductDto : BaseProductDto
{
    public required string Id { get; set; }
    public List<UpdateProductImageDto> Images { get; set; } = [];
    public UpdateProductDetailDto? Details { get; set; }
}