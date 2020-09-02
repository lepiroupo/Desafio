using Desafio.Cache.Interfaces;
using Desafio.Domain.Entities;
using Desafio.ExchangeRates.Proxy.Interfaces;
using Desafio.ExchangeRates.Proxy.Model;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Desafio.ExchangeRates.Proxy
{
    public class ExchangeRatesApiProxy : IExchangeRatesApiProxy
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private ICacheManager _cacheManager;
        public ExchangeRatesApiProxy(HttpClient httpClient, ICacheManager cacheManager)
        {
            _httpClient = httpClient;
            _baseUrl = "https://api.exchangeratesapi.io";
            _cacheManager = cacheManager;
        }

        public async Task<Moeda> ObterUltimaCotacaoMoeda(string siglaMoeda)
        {
            var chaveMoeda = ObterChaveMoedaAtual(siglaMoeda);
            var cache = _cacheManager.ObterChache<Moeda>(chaveMoeda);
            if (cache != null)
                return cache;

            var response = await _httpClient.GetAsync($"{_baseUrl}/latest?base={siglaMoeda}&symbols=BRL");

            response.EnsureSuccessStatusCode();

            var responseBody = JsonSerializer.Deserialize<LatestResult>(await response.Content.ReadAsStringAsync());

            var moeda = new Moeda(siglaMoeda, responseBody.Rates.BRL, responseBody.Date);

            _cacheManager.GravarCache(chaveMoeda, moeda);

            return moeda;
        }

        private string ObterChaveMoedaAtual(string siglaMoeda)
        {
            return $"{siglaMoeda}_{DateTime.Now:yyyyMMdd}";
        }
    }
}
