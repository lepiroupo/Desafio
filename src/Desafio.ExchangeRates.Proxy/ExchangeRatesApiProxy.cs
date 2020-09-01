using Desafio.Domain.Entities;
using Desafio.ExchangeRates.Proxy.Interfaces;
using Desafio.ExchangeRates.Proxy.Model;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Desafio.ExchangeRates.Proxy
{
    public class ExchangeRatesApiProxy : IExchangeRatesApiProxy
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        public ExchangeRatesApiProxy(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _baseUrl = "https://api.exchangeratesapi.io";
        }

        public async Task<Moeda> ObterValorMoeda(string siglaMoeda)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/latest?base={siglaMoeda}&symbols=BRL");

            response.EnsureSuccessStatusCode();

            var responseBody = JsonSerializer.Deserialize<LatestResult>(await response.Content.ReadAsStringAsync());

            return new Moeda(siglaMoeda, responseBody.Rates.BRL);
        }
    }
}
