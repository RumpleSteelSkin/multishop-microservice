using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.DataAccessLayer.Repositories;

public class CargoOperationDal(CargoContext context) : GenericRepository<CargoOperation>(context), ICargoOperationDal;