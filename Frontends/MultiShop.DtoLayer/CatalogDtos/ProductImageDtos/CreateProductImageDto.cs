namespace MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;

public class CreateProductImageDto
{
    public required string Url { get; set; }
    public int Order { get; set; }
    public string? AltText { get; set; }
}