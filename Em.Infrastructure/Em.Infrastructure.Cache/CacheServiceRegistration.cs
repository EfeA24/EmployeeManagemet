using Em.Core.Application.Interfaces.Cache;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Em.Infrastructure.Cache
{
    public static class CacheServiceRegistration
    {
        public static IServiceCollection AddCache(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration["Redis:Configuration"] ?? "localhost:6379";
            });

            services.AddSingleton<ICacheService, RedisCacheService>();

            return services;
        }
    }
}
