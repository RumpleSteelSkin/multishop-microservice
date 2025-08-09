using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Concrete;

public class CargoCompanyManager(ICargoCompanyDal dal) : ICargoCompanyService
{
    public void Insert(CargoCompany entity)
    {
        dal.Insert(entity);
    }

    public void Update(CargoCompany entity)
    {
        dal.Update(entity);
    }

    public void Delete(int id)
    {
        dal.Delete(id);
    }

    public CargoCompany GetById(int id)
    {
        return dal.GetById(id);
    }

    public ICollection<CargoCompany> GetAll()
    {
        return dal.GetAll();
    }
}