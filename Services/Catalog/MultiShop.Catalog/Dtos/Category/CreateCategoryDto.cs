namespace MultiShop.Catalog.Dtos.Category;

public class CreateCategoryDto
{
    public required string Name { get; set; }
    public string? ImageUrl { get; set; }
}