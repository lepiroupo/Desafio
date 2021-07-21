using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace Desafio.Api.Configuration
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection IntegrateSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c => {
                
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Desafio",
                        Version = "v1",
                        Description = "API REST para obter cotação de moedas",
                        Contact = new OpenApiContact
                        {
                            Name = "Leandro Piroupo",
                            Url = new Uri("https://github.com/lepiroupo")
                        }
                    });
                c.EnableAnnotations();
            });
            return services;
        }
    }
}
