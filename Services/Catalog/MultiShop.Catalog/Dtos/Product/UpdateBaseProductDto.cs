using MultiShop.Catalog.Dtos.ProductDetail;
using MultiShop.Catalog.Dtos.ProductImage;

namespace MultiShop.Catalog.Dtos.Product;

public class UpdateBaseProductDto : BaseProductDto
{
    public required string Id { get; set; }
    public List<UpdateProductImageDto> Images { get; set; } = [];
    public UpdateProductDetailDto? Details { get; set; }
}