namespace MultiShop.Order.Application.Features.Mediator.Results.OrderingResults;

public class GetOrderingByUserIdQueryResult
{
    public int Id { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
}