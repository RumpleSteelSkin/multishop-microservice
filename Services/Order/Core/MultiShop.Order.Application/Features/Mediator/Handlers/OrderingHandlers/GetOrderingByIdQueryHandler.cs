using MediatR;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class GetOrderingByIdQueryHandler(IRepository<Ordering, int> repository)
    : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
{
    public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request,
        CancellationToken cancellationToken)
    {
        var value = await repository.GetByIdAsync(request.Id, cancellationToken);
        return new GetOrderingByIdQueryResult
        {
            UserId = value.UserId,
            TotalPrice = value.TotalPrice,
            OrderDate = value.OrderDate,
        };
    }
}