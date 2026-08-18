using System.Collections;
using Dapper;
using Em.Core.Application.Interfaces.Dapper;
using Em.Infrastructure.Persistance.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Em.Infrastructure.Persistance.Dapper
{
    public class DapperQuery : IDapperQuery
    {
        private readonly ISqlConnectionFactory _connectionFactory;
        private readonly AppDbContext _context;

        static DapperQuery()
        {
            SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());
            SqlMapper.AddTypeHandler(new NullableDateOnlyTypeHandler());
        }

        public DapperQuery(ISqlConnectionFactory connectionFactory, AppDbContext context)
        {
            _connectionFactory = connectionFactory;
            _context = context;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync<T>(CancellationToken cancellationToken = default) where T : class
        {
            if (typeof(T).IsAbstract)
                return await GetAllForAbstractAsync<T>(cancellationToken);

            var (tableSql, discriminatorColumn, discriminatorValue) = ResolveTable<T>();
            var sql = $"SELECT * FROM {tableSql}";
            object? parameters = null;

            if (discriminatorColumn is not null && discriminatorValue is not null)
            {
                sql += $" WHERE [{discriminatorColumn}] = @Discriminator";
                parameters = new { Discriminator = discriminatorValue };
            }

            using var connection = _connectionFactory.CreateConnection();
            var command = new CommandDefinition(sql, parameters, cancellationToken: cancellationToken);
            var result = await connection.QueryAsync<T>(command);
            return result.AsList();
        }

        public async Task<T?> GetByIdAsync<T>(Guid id, CancellationToken cancellationToken = default) where T : class
        {
            if (typeof(T).IsAbstract)
                return await GetByIdForAbstractAsync<T>(id, cancellationToken);

            var (tableSql, discriminatorColumn, discriminatorValue) = ResolveTable<T>();
            var sql = $"SELECT * FROM {tableSql} WHERE [Id] = @Id";
            object parameters;

            if (discriminatorColumn is not null && discriminatorValue is not null)
            {
                sql += $" AND [{discriminatorColumn}] = @Discriminator";
                parameters = new { Id = id, Discriminator = discriminatorValue };
            }
            else
            {
                parameters = new { Id = id };
            }

            using var connection = _connectionFactory.CreateConnection();
            var command = new CommandDefinition(sql, parameters, cancellationToken: cancellationToken);
            return await connection.QuerySingleOrDefaultAsync<T>(command);
        }

        private async Task<IReadOnlyList<T>> GetAllForAbstractAsync<T>(CancellationToken cancellationToken) where T : class
        {
            var results = new List<T>();
            var method = typeof(DapperQuery).GetMethods()
                .Single(m => m.Name == nameof(GetAllAsync) && m.IsGenericMethodDefinition);

            foreach (var derivedType in GetConcreteDerivedTypes<T>())
            {
                var task = (Task)method.MakeGenericMethod(derivedType).Invoke(this, [cancellationToken])!;
                await task.ConfigureAwait(false);
                if (task.GetType().GetProperty("Result")?.GetValue(task) is not IEnumerable items)
                    continue;

                foreach (var item in items)
                {
                    if (item is T typed)
                        results.Add(typed);
                }
            }

            return results;
        }

        private async Task<T?> GetByIdForAbstractAsync<T>(Guid id, CancellationToken cancellationToken) where T : class
        {
            var method = typeof(DapperQuery).GetMethods()
                .Single(m => m.Name == nameof(GetByIdAsync) && m.IsGenericMethodDefinition);

            foreach (var derivedType in GetConcreteDerivedTypes<T>())
            {
                var task = (Task)method.MakeGenericMethod(derivedType).Invoke(this, [id, cancellationToken])!;
                await task.ConfigureAwait(false);
                var result = task.GetType().GetProperty("Result")?.GetValue(task);
                if (result is T typed)
                    return typed;
            }

            return null;
        }

        private IEnumerable<Type> GetConcreteDerivedTypes<T>() where T : class
        {
            return _context.Model.GetEntityTypes()
                .Select(entityType => entityType.ClrType)
                .Where(clrType => clrType is { IsAbstract: false } && typeof(T).IsAssignableFrom(clrType) && clrType != typeof(T))
                .Distinct();
        }

        private (string TableSql, string? DiscriminatorColumn, object? DiscriminatorValue) ResolveTable<T>() where T : class
        {
            var entityType = _context.Model.FindEntityType(typeof(T))
                ?? throw new InvalidOperationException($"Entity type '{typeof(T).Name}' is not mapped in AppDbContext.");

            var tableName = entityType.GetTableName()
                ?? throw new InvalidOperationException($"Table name for '{typeof(T).Name}' was not found.");

            var schema = entityType.GetSchema();
            var tableSql = string.IsNullOrWhiteSpace(schema)
                ? $"[{tableName}]"
                : $"[{schema}].[{tableName}]";

            if (typeof(T).IsAbstract)
                return (tableSql, null, null);

            var discriminatorProperty = entityType.FindDiscriminatorProperty();
            var discriminatorValue = entityType.GetDiscriminatorValue();
            if (discriminatorProperty is null || discriminatorValue is null)
                return (tableSql, null, null);

            var columnName = discriminatorProperty.GetColumnName(StoreObjectIdentifier.Table(tableName, schema));
            return (tableSql, columnName ?? discriminatorProperty.Name, discriminatorValue);
        }
    }
}
