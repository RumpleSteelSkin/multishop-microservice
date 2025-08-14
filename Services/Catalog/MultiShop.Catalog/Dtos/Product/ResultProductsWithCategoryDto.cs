using MultiShop.Catalog.Dtos.Category;
using MultiShop.Catalog.Dtos.ProductDetail;
using MultiShop.Catalog.Dtos.ProductImage;

namespace MultiShop.Catalog.Dtos.Product;

public class ResultProductsWithCategoryDto
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }

    public List<ResultProductImageDto> Images { get; set; } = [];
    public ResultProductDetailDto? Details { get; set; }
    public ResultCategoryDto? Category { get; set; }
}