using Desafio.ExchangeRates.Proxy.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace Desafio.ExchangeRates.Proxy
{
    public class ExchangeRatesApiProxy : IExchangeRatesApiProxy
    {
        //static readonly HttpClient httpClient = new HttpClient();
        public async Task<decimal> ObterValorMoeda(string moeda)
        {
            return await Task.FromResult(2);
        }
    }
}
