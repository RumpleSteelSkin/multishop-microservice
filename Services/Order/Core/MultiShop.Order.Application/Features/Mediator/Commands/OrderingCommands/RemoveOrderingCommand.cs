using MediatR;

namespace MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;

public class RemoveOrderingCommand(int id) : IRequest<string>
{
    public int Id { get; set; } = id;
}