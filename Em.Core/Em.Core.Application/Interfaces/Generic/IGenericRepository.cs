using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Em.Core.Application.Interfaces.Generic
{
    public interface IGenericRepository <T> where T : class
    {
        Task CreateAsync(T entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);

        Task<T?> GetByIdAsync(Guid? id, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default);
        Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken ct = default);
        IQueryable<T> Query(bool asNoTracking = true);
    }
}
