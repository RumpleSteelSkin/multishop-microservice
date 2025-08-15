namespace MultiShop.Catalog.Dtos.SpecialOffer;

public class ResultSpecialOfferDto
{
    public required string Id { get; set; }
    public required string Title { get; set; }
    public string? SubTitle { get; set; }
    public string? ImageUrl { get; set; }
}