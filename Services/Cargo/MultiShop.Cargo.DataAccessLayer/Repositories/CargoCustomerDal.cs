using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.DataAccessLayer.Repositories;

public class CargoCustomerDal(CargoContext context) : GenericRepository<CargoCustomer>(context), ICargoCustomerDal;