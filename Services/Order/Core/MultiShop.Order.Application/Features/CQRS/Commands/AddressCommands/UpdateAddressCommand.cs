namespace MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;

public class UpdateAddressCommand
{
    public required int Id { get; set; }
    public required string UserId { get; set; }
    public string? District { get; set; }
    public string? City { get; set; }
    public string? Detail { get; set; }
}