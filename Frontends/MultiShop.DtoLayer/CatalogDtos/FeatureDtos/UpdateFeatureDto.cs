namespace MultiShop.DtoLayer.CatalogDtos.FeatureDtos;

public class UpdateFeatureDto
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public string? Icon { get; set; }
}