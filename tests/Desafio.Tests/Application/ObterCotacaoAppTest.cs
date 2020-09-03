using Desafio.App;
using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.ExchangeRates.Proxy.Interfaces;
using Moq.AutoMock;
using System.Threading.Tasks;
using Xunit;

namespace Desafio.Tests.Application
{
    public class ObterCotacaoAppTest
    {
        [Fact(DisplayName = "Obter cotação de 100 dolares para cliente varejo. Deve retornar 220 reais.")]
        [Trait("Application", "ObterCotacao")]
        public async Task ObterCotacaoMoeda_100Dolares_ClienteVarejo_DeveRetornar220()
        {
            //arrange
            var mocker = new AutoMocker();
            var app = mocker.CreateInstance<CotacaoApp>();

            mocker.GetMock<IClienteRepository>().Setup(r => r.ObterClientePorId(1)).Returns(new Cliente(1, "Teste", "12345678901", Domain.Enums.Segmento.Varejo));
            mocker.GetMock<ITaxaRepository>().Setup(r => r.ObterTaxaCambioPorSegmento(Domain.Enums.Segmento.Varejo)).Returns(new TaxaCambio(Domain.Enums.Segmento.Varejo, 0.1M));
            mocker.GetMock<IExchangeRatesApiProxy>().Setup(r => r.ObterUltimaCotacaoMoeda("USD")).Returns(Task.FromResult(2M));

            //act
            var response = await app.ObterCotacaoMoeda(1, "USD", 100);

            //assert
            Assert.Equal(220, response.ValorTotal);
        }
    }
}
