namespace MultiShop.Cargo.BusinessLayer.Abstract;

public interface IGenericService<T> where T : class
{
    void Insert(T entity);
    void Update(T entity);
    void Delete(int id);
    T GetById(int id);
    ICollection<T> GetAll();
}