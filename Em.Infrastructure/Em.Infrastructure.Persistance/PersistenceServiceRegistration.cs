using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Interfaces.Generic;
using Em.Infrastructure.Persistance.Dapper;
using Em.Infrastructure.Persistance.EfCore;
using Em.Infrastructure.Persistance.Implementations.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Em.Infrastructure.Persistance
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<ISqlConnectionFactory, SqlConnectionFactory>();
            services.AddScoped<IDapperQuery, DapperQuery>();

            return services;
        }
    }
}
