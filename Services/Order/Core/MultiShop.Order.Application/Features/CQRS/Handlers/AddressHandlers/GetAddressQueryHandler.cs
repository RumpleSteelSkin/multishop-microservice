using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class GetAddressQueryHandler(IRepository<Address, int> repository)
{
    public async Task<ICollection<GetAddressQueryResult>> Handle()
    {
        var values = await repository.GetAllAsync();
        return values.Select(x => new GetAddressQueryResult
        {
            Id = x.Id,
            City = x.City,
            District = x.District,
            Detail = x.Detail,
            UserId = x.UserId
        }).ToList();
    }
}