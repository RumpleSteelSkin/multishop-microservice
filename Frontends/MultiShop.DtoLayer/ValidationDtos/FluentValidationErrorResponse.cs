namespace MultiShop.DtoLayer.ValidationDtos;

public class FluentValidationErrorResponse
{
    public string? Type { get; set; }
    public string? Title { get; set; }
    public int Status { get; set; }
    public ICollection<ValidationError>? Errors { get; set; }
}