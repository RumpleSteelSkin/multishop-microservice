using MultiShop.Catalog.Dtos.Category;
using MultiShop.Catalog.Dtos.ProductDetail;
using MultiShop.Catalog.Dtos.ProductImage;

namespace MultiShop.Catalog.Dtos.Product;

public class GetByIdProductDto
{
    public required string Name { get; set; }
    public decimal Price { get; set; }

    public List<GetByIdProductImageDto> Images { get; set; } = [];
    public GetByIdProductDetailDto? Details { get; set; }
    public string? CategoryId { get; set; }
}