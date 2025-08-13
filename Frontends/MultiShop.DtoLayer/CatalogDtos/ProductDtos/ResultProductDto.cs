using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;

namespace MultiShop.DtoLayer.CatalogDtos.ProductDtos;

public class ResultProductDto
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }

    public List<ResultProductImageDto> Images { get; set; } = [];
    public ResultProductDetailDto? Details { get; set; }
    public string? CategoryId { get; set; }
}