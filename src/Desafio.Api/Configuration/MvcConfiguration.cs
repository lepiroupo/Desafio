using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

namespace Desafio.Api.Configuration
{
    public static class MvcConfiguration
    {
        public static IServiceCollection IntegrateMvc(this IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });
            return services;
        }
    }
}
