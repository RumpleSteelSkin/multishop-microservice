using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class RemoveOrderingCommandHandler(IRepository<Ordering, int> repository)
    : IRequestHandler<RemoveOrderingCommand, string>
{
    public async Task<string> Handle(RemoveOrderingCommand request, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(await repository.GetByIdAsync(request.Id, cancellationToken), cancellationToken);
        return "Ordering removed";
    }
}