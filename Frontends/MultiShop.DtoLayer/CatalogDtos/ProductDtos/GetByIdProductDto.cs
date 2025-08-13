using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;

namespace MultiShop.DtoLayer.CatalogDtos.ProductDtos;

public class GetByIdProductDto
{
    public required string Name { get; set; }
    public decimal Price { get; set; }

    public List<GetByIdProductImageDto> Images { get; set; } = [];
    public GetByIdProductDetailDto? Details { get; set; }
    public string? CategoryId { get; set; }
}