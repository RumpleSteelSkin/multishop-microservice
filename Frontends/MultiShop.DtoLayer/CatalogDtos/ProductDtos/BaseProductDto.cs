namespace MultiShop.DtoLayer.CatalogDtos.ProductDtos;

public abstract class BaseProductDto
{
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public string? CategoryId { get; set; }
}