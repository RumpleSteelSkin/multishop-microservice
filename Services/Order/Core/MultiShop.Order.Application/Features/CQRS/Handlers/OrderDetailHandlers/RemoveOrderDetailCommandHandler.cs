using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class RemoveOrderDetailCommandHandler(IRepository<OrderDetail, int> repository)
{
    public async Task Handle(RemoveOrderDetailCommand  command)
    {
        await repository.DeleteAsync(await repository.GetByIdAsync(command.Id));
    }
}