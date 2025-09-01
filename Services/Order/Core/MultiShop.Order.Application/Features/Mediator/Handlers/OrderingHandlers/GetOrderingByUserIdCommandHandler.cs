using MediatR;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class GetOrderingByUserIdCommandHandler(IRepository<Ordering, int> repository)
    : IRequestHandler<GetOrderingByUserIdQuery, ICollection<GetOrderingByUserIdQueryResult>>
{
    public async Task<ICollection<GetOrderingByUserIdQueryResult>> Handle(GetOrderingByUserIdQuery request,
        CancellationToken cancellationToken)
    {
        return (await repository.GetAllByFilterAsync(x => x.UserId == request.UserId, cancellationToken)).Select(item =>
            new GetOrderingByUserIdQueryResult
                { Id = item.Id, OrderDate = item.OrderDate, TotalPrice = item.TotalPrice, }).ToList();
    }
}