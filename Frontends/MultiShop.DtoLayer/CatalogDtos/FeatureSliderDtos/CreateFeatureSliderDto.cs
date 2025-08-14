namespace MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;

public class CreateFeatureSliderDto
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string ImageUrl { get; set; }
    public required bool Status { get; set; }
}