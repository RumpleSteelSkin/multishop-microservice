namespace MultiShop.Catalog.Dtos.Category;

public class UpdateCategoryDto
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public string? ImageUrl { get; set; }
}