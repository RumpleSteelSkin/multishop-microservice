namespace MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;

public class UpdateProductImageDto
{
    public required string Url { get; set; }
    public int Order { get; set; }
    public string? AltText { get; set; }
}