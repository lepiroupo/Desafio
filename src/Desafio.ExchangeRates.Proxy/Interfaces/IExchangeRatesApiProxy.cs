using Desafio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.ExchangeRates.Proxy.Interfaces
{
    public interface IExchangeRatesApiProxy
    {
        Task<Moeda> ObterUltimaCotacaoMoeda(string moeda);
    }
}
