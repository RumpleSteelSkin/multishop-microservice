namespace MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;

public class GetOrderDetailQueryResult
{
    public int Id { get; set; }
    public string? ProductId { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public int Amount { get; set; }
    public decimal TotalPrice { get; set; }
    public int OrderingId { get; set; }
}