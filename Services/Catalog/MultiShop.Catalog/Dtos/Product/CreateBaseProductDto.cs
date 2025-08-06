using MultiShop.Catalog.Dtos.ProductDetail;
using MultiShop.Catalog.Dtos.ProductImage;

namespace MultiShop.Catalog.Dtos.Product;

public class CreateBaseProductDto : BaseProductDto
{
    public List<CreateProductImageDto> Images { get; set; } = [];
    public CreateProductDetailDto? Details { get; set; }
}