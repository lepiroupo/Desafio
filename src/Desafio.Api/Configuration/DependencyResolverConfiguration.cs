﻿using Desafio.App;
using Desafio.App.Interfaces;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.ExchangeRates.Proxy;
using Desafio.ExchangeRates.Proxy.Interfaces;
using Desafio.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Api.Configuration
{
    public static class DependencyResolverConfiguration
    {
        public static IServiceCollection IntegrateDependencyResolver(this IServiceCollection services)
        {

            return services.RegisterApp().RegisterRepository().RegisterExternalServices();
        }

        private static IServiceCollection RegisterApp(this IServiceCollection services)
        {
            services.AddScoped<ICotacaoApp, CotacaoApp>();
            return services;
        }
        private static IServiceCollection RegisterRepository(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ITaxaRepository, TaxaRepository>();
            return services;
        }
        private static IServiceCollection RegisterExternalServices(this IServiceCollection services)
        {
            services.AddScoped<IExchangeRatesApiProxy, ExchangeRatesApiProxy>();
            return services;
        }
    }
}
