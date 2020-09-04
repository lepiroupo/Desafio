using Desafio.Cache.Interfaces;
using Desafio.ExchangeRates.Proxy.Dtos;
using Desafio.ExchangeRates.Proxy.Interfaces;
using Desafio.ExchangeRates.Proxy.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Desafio.ExchangeRates.Proxy
{
    public class ExchangeRatesApiProxy : IExchangeRatesApiProxy
    {
        private readonly IHttpClientFactory _clientFactory;
        private ICacheManager _cacheManager;
        public ExchangeRatesApiProxy(IHttpClientFactory clientFactory, ICacheManager cacheManager)
        {
            _clientFactory = clientFactory;
            _cacheManager = cacheManager;
        }

        public async Task<decimal> ObterUltimaCotacaoMoeda(string siglaMoeda)
        {
            var chaveMoeda = ObterChaveMoedaAtual(siglaMoeda);
            var cache = _cacheManager.ObterChache<MoedaDto>(chaveMoeda);
            if (cache != null)
                return cache.ValorEmReais;

            var client = _clientFactory.CreateClient("exchangeRates");
            var response = await client.GetAsync($"latest?base={siglaMoeda}&symbols=BRL");

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return 0M;

            var responseBody = JsonSerializer.Deserialize<LatestResult>(await response.Content.ReadAsStringAsync());

            var moedaDto = new MoedaDto(siglaMoeda, responseBody.Rates.BRL, responseBody.Date);

            _cacheManager.GravarCache(chaveMoeda, moedaDto);

            return moedaDto.ValorEmReais;
        }

        private string ObterChaveMoedaAtual(string siglaMoeda)
        {
            return $"{siglaMoeda}_{DateTime.Now:yyyyMMdd}";
        }
    }
}
