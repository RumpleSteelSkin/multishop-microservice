using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services;

public class DiscountService(DapperContext context) : IDiscountService
{
    public async Task<List<ResultCouponDto>> GetAll()
    {
        using var conn = context.CreateConnection();
        return (await conn.QueryAsync<ResultCouponDto>("SELECT * FROM Coupons")).ToList();
    }

    public async Task Create(CreateCouponDto createCouponDto)
    {
        using var conn = context.CreateConnection();
        await conn.ExecuteAsync(
            "INSERT INTO Coupons (Code, Rate, IsActive, ValidDate) VALUES (@Code, @Rate, @IsActive, @ValidDate);",
            createCouponDto);
    }

    public async Task Update(UpdateCouponDto updateCouponDto)
    {
        using var conn = context.CreateConnection();
        await conn.ExecuteAsync(
            "UPDATE Coupons SET Code=@Code, Rate=@Rate, IsActive=@IsActive, ValidDate=@ValidDate WHERE Id=@Id",
            updateCouponDto);
    }

    public async Task Delete(int id)
    {
        using var conn = context.CreateConnection();
        await conn.ExecuteAsync("DELETE FROM Coupons WHERE Id = @Id;", new { id });
    }

    public async Task<GetByIdCouponDto> GetById(int id)
    {
        using var conn = context.CreateConnection();
        return await conn.QueryFirstAsync<GetByIdCouponDto>("SELECT * FROM Coupons WHERE Id = @Id;", new { id });
    }
}