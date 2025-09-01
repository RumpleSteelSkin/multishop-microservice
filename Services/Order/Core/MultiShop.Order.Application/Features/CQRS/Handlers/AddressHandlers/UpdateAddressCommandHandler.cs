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
        value.Detail1 = command.Detail1;
        value.Detail2 = command.Detail2;
        value.Email = command.Email;
        value.Name = command.Name;
        value.Phone = command.Phone;
        value.ZipCode = command.ZipCode;
        value.Description = command.Description;
        value.Country = command.Country;
        value.Surname = command.Surname;
        await repository.UpdateAsync(value);
    }
}