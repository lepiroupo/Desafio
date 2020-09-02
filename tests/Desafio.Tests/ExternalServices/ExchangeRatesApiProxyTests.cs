using Desafio.Cache.Interfaces;
using Desafio.Domain.Entities;
using Desafio.ExchangeRates.Proxy;
using Moq;
using Moq.AutoMock;
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
            var mocker = new AutoMocker();
            var proxy = mocker.CreateInstance<ExchangeRatesApiProxy>();
            mocker.GetMock<ICacheManager>().Setup(c => c.ObterChache<Moeda>(It.IsAny<string>())).Returns(new Moeda("USD", 5, "2020-08-31"));

            //act
            var moeda = await proxy.ObterUltimaCotacaoMoeda("USD");

            //assert
            Assert.NotEqual(0, moeda.ValorEmReais);
        }
    }
}
