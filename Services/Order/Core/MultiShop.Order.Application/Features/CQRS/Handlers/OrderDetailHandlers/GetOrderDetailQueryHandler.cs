using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class GetOrderDetailQueryHandler(IRepository<OrderDetail, int> repository)
{
    public async Task<ICollection<GetOrderDetailQueryResult>> Handle()
    {
        var values = await repository.GetAllAsync();
        return values.Select(x => new GetOrderDetailQueryResult
        {
            Id = x.Id,
            Name = x.Name,
            Amount = x.Amount,
            Price = x.Price,
            OrderingId = x.OrderingId,
            ProductId = x.ProductId,
            TotalPrice = x.TotalPrice,
        }).ToList();
    }
}