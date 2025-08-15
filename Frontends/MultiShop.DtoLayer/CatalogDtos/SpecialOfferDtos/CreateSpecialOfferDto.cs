namespace MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;

public class CreateSpecialOfferDto
{
    public required string Title { get; set; }
    public string? SubTitle { get; set; }
    public string? ImageUrl { get; set; }
}