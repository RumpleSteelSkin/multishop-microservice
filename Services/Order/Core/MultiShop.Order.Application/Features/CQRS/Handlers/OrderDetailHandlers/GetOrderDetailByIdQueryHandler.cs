using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class GetOrderDetailByIdQueryHandler(IRepository<OrderDetail, int> repository)
{
    public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery command)
    {
        var values = await repository.GetByIdAsync(command.Id);
        return new GetOrderDetailByIdQueryResult
        {
            Amount = values.Amount,
            ProductId = values.ProductId,
            TotalPrice = values.TotalPrice,
            OrderingId = values.OrderingId,
            Price = values.Price,
            Name = values.Name,
        };
    }
}