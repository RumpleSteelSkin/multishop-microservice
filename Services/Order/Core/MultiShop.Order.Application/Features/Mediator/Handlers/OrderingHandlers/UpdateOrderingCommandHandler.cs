using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class UpdateOrderingCommandHandler(IRepository<Ordering, int> repository)
    : IRequestHandler<UpdateOrderingCommand, string>
{
    public async Task<string> Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
    {
        var value = await repository.GetByIdAsync(request.Id, cancellationToken);
        value.TotalPrice = request.TotalPrice;
        value.OrderDate = request.OrderDate;
        value.UserId = request.UserId;
        await repository.UpdateAsync(value, cancellationToken);
        return "Ordering updated";
    }
}