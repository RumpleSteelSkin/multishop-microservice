namespace MultiShop.Catalog.Dtos.About;

public class UpdateAboutDto
{
    public required string Id { get; set; }
    public string? Description { get; set; }
    public string? Address { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
}