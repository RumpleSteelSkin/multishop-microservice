using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class CreateAddressCommandHandler(IRepository<Address, int> repository)
{
    public async Task Handle(CreateAddressCommand command)
    {
        await repository.CreateAsync(new Address
        {
            City = command.City,
            Detail = command.Detail,
            District = command.District,
            UserId = command.UserId
        });
    }
}