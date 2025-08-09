using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Concrete;

public class CargoCustomerManager(ICargoCustomerDal dal) : ICargoCustomerService
{
    public void Insert(CargoCustomer entity)
    {
        dal.Insert(entity);
    }

    public void Update(CargoCustomer entity)
    {
        dal.Update(entity);
    }

    public void Delete(int id)
    {
        dal.Delete(id);
    }

    public CargoCustomer GetById(int id)
    {
        return dal.GetById(id);
    }

    public ICollection<CargoCustomer> GetAll()
    {
        return dal.GetAll();
    }
}