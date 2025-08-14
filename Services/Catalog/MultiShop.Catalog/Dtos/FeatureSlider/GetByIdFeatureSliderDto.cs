namespace MultiShop.Catalog.Dtos.FeatureSlider;

public class GetByIdFeatureSliderDto
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string ImageUrl { get; set; }
    public required bool Status { get; set; }
}