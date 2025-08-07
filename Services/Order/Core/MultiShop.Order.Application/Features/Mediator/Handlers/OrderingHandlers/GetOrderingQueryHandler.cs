using MediatR;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class GetOrderingQueryHandler(IRepository<Ordering, int> repository)
    : IRequestHandler<GetOrderingQuery, ICollection<GetOrderingQueryResult>>
{
    public async Task<ICollection<GetOrderingQueryResult>> Handle(GetOrderingQuery request,
        CancellationToken cancellationToken)
    {
        var values = await repository.GetAllAsync(cancellationToken);
        return values.Select(x => new GetOrderingQueryResult
        {
            Id = x.Id,
            UserId = x.UserId,
            TotalPrice = x.TotalPrice,
            OrderDate = x.OrderDate,
        }).ToList();
    }
}