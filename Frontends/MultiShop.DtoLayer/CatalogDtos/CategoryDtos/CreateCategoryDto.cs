namespace MultiShop.DtoLayer.CatalogDtos.CategoryDtos;

public class CreateCategoryDto
{
    public required string Name { get; set; }
    public string? ImageUrl { get; set; }
}