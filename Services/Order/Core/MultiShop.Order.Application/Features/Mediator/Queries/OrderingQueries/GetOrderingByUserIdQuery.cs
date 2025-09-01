using MediatR;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResults;

namespace MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;

public class GetOrderingByUserIdQuery : IRequest<ICollection<GetOrderingByUserIdQueryResult>>
{
    public string? UserId { get; set; }
}