using Em.Core.Application.Interfaces.Generic;
using Em.Infrastructure.Persistance.EfCore;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Em.Infrastructure.Persistance.Implementations.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext Context;
        protected readonly DbSet<T> DbSet;

        public GenericRepository(AppDbContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public async Task CreateAsync(T entity, CancellationToken cancellationToken = default)
        {
            await DbSet.AddAsync(entity, cancellationToken);
        }

        public Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            DbSet.Update(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            DbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<T?> GetByIdAsync(Guid? id, CancellationToken cancellationToken = default)
        {
            if (id is null)
                return null;

            return await DbSet.FindAsync(new object[] { id.Value }, cancellationToken);
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await DbSet.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default)
        {
            return (await DbSet.FirstOrDefaultAsync(predicate, ct))!;
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken ct = default)
        {
            if (predicate is null)
                return await DbSet.CountAsync(ct);

            return await DbSet.CountAsync(predicate, ct);
        }

        public IQueryable<T> Query(bool asNoTracking = true)
        {
            return asNoTracking ? DbSet.AsNoTracking() : DbSet.AsQueryable();
        }
    }
}
