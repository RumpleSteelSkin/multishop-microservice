using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class RemoveAddressCommandHandler(IRepository<Address, int> repository)
{
    public async Task Handle(RemoveAddressCommand command)
    {
        await repository.DeleteAsync(await repository.GetByIdAsync(command.Id));
    }
}