using System.Linq.Expressions;

namespace MultiShop.Order.Application.Interfaces;

public interface IRepository<T, TId> where T : class
{
    Task<T> GetByIdAsync(TId id, CancellationToken cancellationToken = default);
    Task<T> GetByFilterAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    Task<ICollection<T>> GetAllByFilterAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    Task<ICollection<T>> GetAllAsync(CancellationToken cancellationToken = default);
    Task CreateAsync(T entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
}