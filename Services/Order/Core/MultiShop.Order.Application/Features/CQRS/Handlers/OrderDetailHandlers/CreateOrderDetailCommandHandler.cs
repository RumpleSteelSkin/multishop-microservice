using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class CreateOrderDetailCommandHandler(IRepository<OrderDetail, int> repository)
{
    public async Task Handle(CreateOrderDetailCommand command)
    {
        await repository.CreateAsync(new OrderDetail
        {
            Amount = command.Amount,
            ProductId = command.ProductId,
            TotalPrice = command.TotalPrice,
            OrderingId = command.OrderingId,
            Price = command.Price,
            Name = command.Name
        });
    }
}