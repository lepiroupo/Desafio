using Desafio.ExchangeRates.Proxy;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Desafio.Tests.ExternalServices
{
    public class ExchangeRatesApiProxyTests
    {
        [Fact(DisplayName ="Obter o valor da moeda estranageira. Deve retornar valor em reais.")]
        [Trait("ExternalServices", "ExchangeRates")]
        public async Task ObterValorMoeda_RealParaDolarAmericano()
        {
            //arrange
            var proxy = new ExchangeRatesApiProxy(new HttpClient());

            //act
            var moeda = await proxy.ObterValorMoeda("USD");

            //assert
            Assert.NotEqual(0, moeda.ValorEmReais);
        }
    }
}
