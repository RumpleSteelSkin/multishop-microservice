using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services;

public interface IDiscountService
{
    Task<List<ResultCouponDto>> GetAll();
    Task Create(CreateCouponDto createCouponDto);
    Task Update(UpdateCouponDto updateCouponDto);
    Task Delete(int id);
    Task<GetByIdCouponDto> GetById(int id);
    Task<ResultCouponDto?> GetCodeDetailByCode(string code);
    Task<int> GetCount();

}