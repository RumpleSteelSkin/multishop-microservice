using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class UpdateOrderDetailCommandHandler(IRepository<OrderDetail, int> repository)
{
    public async Task Handle(UpdateOrderDetailCommand command)
    {
        var value = await repository.GetByIdAsync(command.Id);
        value.Amount = command.Amount;
        value.ProductId = command.ProductId;
        value.TotalPrice = command.TotalPrice;
        value.OrderingId = command.OrderingId;
        value.Price = command.Price;
        value.Name = command.Name;
        await repository.UpdateAsync(value);
    }
}