using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Concrete;

public class CargoDetailManager(ICargoDetailDal dal) : ICargoDetailService
{
    public void Insert(CargoDetail entity)
    {
        dal.Insert(entity);
    }

    public void Update(CargoDetail entity)
    {
        dal.Update(entity);
    }

    public void Delete(int id)
    {
        dal.Delete(id);
    }

    public CargoDetail GetById(int id)
    {
        return dal.GetById(id);
    }

    public ICollection<CargoDetail> GetAll()
    {
        return dal.GetAll();
    }
}