namespace MultiShop.DtoLayer.ValidationDtos;

public class ValidationError
{
    public string? Property { get; set; }
    public ICollection<string>? Errors { get; set; }
}