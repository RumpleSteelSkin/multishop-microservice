namespace MultiShop.Catalog.Dtos.Brand;

public class UpdateBrandDto
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public string? ImageUrl { get; set; }
}