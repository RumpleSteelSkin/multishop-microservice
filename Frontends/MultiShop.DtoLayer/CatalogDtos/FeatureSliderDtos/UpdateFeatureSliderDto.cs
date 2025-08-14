namespace MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;

public class UpdateFeatureSliderDto
{
    public required string Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string ImageUrl { get; set; }
    public required bool Status { get; set; }
}