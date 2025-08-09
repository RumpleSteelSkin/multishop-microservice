using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.DataAccessLayer.Repositories;

public class CargoDetailDal(CargoContext context) : GenericRepository<CargoDetail>(context), ICargoDetailDal;