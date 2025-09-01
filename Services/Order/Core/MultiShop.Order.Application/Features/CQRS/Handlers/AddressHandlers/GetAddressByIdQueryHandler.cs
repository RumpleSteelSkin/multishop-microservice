using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class GetAddressByIdQueryHandler(IRepository<Address, int> repository)
{
    public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query)
    {
        var value = await repository.GetByIdAsync(query.Id);
        return new GetAddressByIdQueryResult
        {
            UserId = value.UserId,
            City = value.City,
            District = value.District,
            Detail1 = value.Detail1,
            Detail2 = value.Detail2,
            ZipCode = value.ZipCode,
            Country = value.Country,
            Email = value.Email,
            Surname = value.Surname,
            Description = value.Description,
            Name = value.Name,
            Phone = value.Phone,
        };
    }
}