using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class UpdateAddressCommandHandler(IRepository<Address, int> repository)
{
    public async Task Handle(UpdateAddressCommand command)
    {
        var value = await repository.GetByIdAsync(command.Id);
        value.UserId = command.UserId;
        value.District = command.District;
        value.City = command.City;
        value.Detail = command.Detail;
        await repository.UpdateAsync(value);
    }
}