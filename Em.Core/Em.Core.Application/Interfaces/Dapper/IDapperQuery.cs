namespace Em.Core.Application.Interfaces.Dapper
{
    public interface IDapperQuery
    {
        Task<IReadOnlyList<T>> GetAllAsync<T>(CancellationToken cancellationToken = default) where T : class;
        Task<T?> GetByIdAsync<T>(Guid id, CancellationToken cancellationToken = default) where T : class;
    }
}
