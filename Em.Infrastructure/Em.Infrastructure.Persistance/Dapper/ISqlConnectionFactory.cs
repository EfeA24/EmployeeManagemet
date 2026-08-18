using System.Data;

namespace Em.Infrastructure.Persistance.Dapper
{
    public interface ISqlConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
