using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Desafio.Api.Configuration
{
    public static class CacheConfiguration
    {
        public static IServiceCollection IntegrateCache(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDistributedRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString("RedisConnection");
                options.InstanceName = "DesafioApi";
            });
            return services;
        }
    }
}
