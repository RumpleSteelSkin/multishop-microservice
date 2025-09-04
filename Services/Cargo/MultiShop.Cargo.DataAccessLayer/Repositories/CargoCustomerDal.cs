using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.DataAccessLayer.Repositories;

public class CargoCustomerDal(CargoContext context) : GenericRepository<CargoCustomer>(context), ICargoCustomerDal
{
    public ICollection<CargoCustomer> GetAllByCustomerId(string customerId)
    {
        return context.CargoCustomers.Where(x => x.UserCustomerId != null && x.UserCustomerId == customerId).ToList();
    }
}