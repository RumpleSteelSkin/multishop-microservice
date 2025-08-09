using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;

namespace MultiShop.Cargo.DataAccessLayer.Repositories;

public class GenericRepository<T>(CargoContext context) : IGenericDal<T> where T : class
{
    public void Insert(T entity)
    {
        context.Set<T>().Add(entity);
        context.SaveChanges();
    }

    public void Update(T entity)
    {
        context.Set<T>().Update(entity);
        context.SaveChanges();
    }

    public void Delete(int id)
    {
        context.Set<T>().Remove(context.Set<T>().Find(id) ?? throw new KeyNotFoundException("Entity not found"));
        context.SaveChanges();
    }

    public T GetById(int id)
    {
        return context.Set<T>().Find(id) ?? throw new KeyNotFoundException("Entity not found");
    }

    public ICollection<T> GetAll()
    {
        return context.Set<T>().ToList();
    }
}