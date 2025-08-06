namespace MultiShop.Catalog.Dtos.ProductImage;

public class ResultProductImageDto
{
    public required string Url { get; set; }
    public int Order { get; set; }
    public string? AltText { get; set; }
}