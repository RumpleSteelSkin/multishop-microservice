using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Persistence.Context;

namespace MultiShop.Order.Persistence.Repositories;

public class Repository<T, TId>(OrderContext context) : IRepository<T, TId> where T : class
{
    public async Task<T> GetByIdAsync(TId id, CancellationToken cancellationToken = default)
    {
        return await context.Set<T>().FindAsync([id], cancellationToken: cancellationToken) ??
               throw new InvalidOperationException("No record found with the specified id");
    }

    public async Task<ICollection<T>> GetAllByFilterAsync(Expression<Func<T, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        return await context.Set<T>().Where(predicate).ToListAsync(cancellationToken) ??
               throw new InvalidOperationException("Entities not found");
    }

    public async Task<ICollection<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await context.Set<T>().ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task CreateAsync(T entity, CancellationToken cancellationToken = default)
    {
        context.Set<T>().Add(entity);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        context.Set<T>().Update(entity);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        context.Set<T>().Remove(entity);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        return await context.Set<T>().FirstOrDefaultAsync(predicate, cancellationToken) ??
               throw new InvalidOperationException("Entity not found");
    }
}