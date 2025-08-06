namespace MultiShop.Catalog.Entities;

public class ProductImage
{
    public required string Url { get; set; }
    public int Order { get; set; }
    public string? AltText { get; set; }
}