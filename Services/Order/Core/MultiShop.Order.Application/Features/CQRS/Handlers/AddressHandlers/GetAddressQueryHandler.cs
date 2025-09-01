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
            Detail1 = x.Detail1,
            UserId = x.UserId,
            ZipCode = x.ZipCode,
            Phone = x.Phone,
            Name = x.Name,
            Surname = x.Surname,
            Country = x.Country,
            Description = x.Description,
            Email = x.Email,
            Detail2 = x.Detail2,
        }).ToList();
    }
}