using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class CreateOrderingCommandHandler(IRepository<Ordering, int> repository)
    : IRequestHandler<CreateOrderingCommand, string>
{
    public async Task<string> Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
    {
        await repository.CreateAsync(new Ordering
        {
            UserId = request.UserId,
            TotalPrice = request.TotalPrice,
            OrderDate = request.OrderDate
        }, cancellationToken);
        return "Ordering created";
    }
}