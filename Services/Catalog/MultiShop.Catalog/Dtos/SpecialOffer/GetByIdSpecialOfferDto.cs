namespace MultiShop.Catalog.Dtos.SpecialOffer;

public class GetByIdSpecialOfferDto
{
    public required string Title { get; set; }
    public string? SubTitle { get; set; }
    public string? ImageUrl { get; set; }
}