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
            Detail1 = command.Detail1,
            District = command.District,
            Detail2 = command.Detail2,
            Description = command.Description,
            Country = command.Country,
            Email = command.Email,
            Name = command.Name,
            Phone = command.Phone,
            Surname = command.Surname,
            UserId = command.UserId,
            ZipCode = command.ZipCode
        });
    }
}