using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Concrete;

public class CargoOperationManager(ICargoOperationDal dal) : ICargoOperationService
{
    public void Insert(CargoOperation entity)
    {
        dal.Insert(entity);
    }

    public void Update(CargoOperation entity)
    {
        dal.Update(entity);
    }

    public void Delete(int id)
    {
        dal.Delete(id);
    }

    public CargoOperation GetById(int id)
    {
        return dal.GetById(id);
    }

    public ICollection<CargoOperation> GetAll()
    {
        return dal.GetAll();
    }
}