using Desafio.Api.Model.Enums;
using Desafio.Api.Model.Requests;
using Desafio.App;
using Desafio.App.Validation;
using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.ExchangeRates.Proxy.Interfaces;
using Desafio.Message.Notifications;
using Moq.AutoMock;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Desafio.Tests.Application
{
    public class ObterCotacaoAppTest
    {
        [Fact(DisplayName = "Obter cotação de 100 dolares para cliente com taxa de 10%. Deve retornar 220 reais.")]
        [Trait("Application", "ObterCotacao")]
        public async Task ObterCotacaoMoeda_100Dolares_TaxaDe10PorCento_DeveRetornar220()
        {
            //arrange
            var mocker = new AutoMocker();
            var app = mocker.CreateInstance<CotacaoApp>();

            mocker.GetMock<IClienteRepository>().Setup(r => r.ObterClientePorId(1)).Returns(new Cliente(1, "Teste", "12345678901", Domain.Enums.Segmento.Varejo));
            mocker.GetMock<ITaxaRepository>().Setup(r => r.ObterTaxaCambioPorSegmento(Domain.Enums.Segmento.Varejo)).Returns(new TaxaCambio(Domain.Enums.Segmento.Varejo, 0.1M));
            mocker.GetMock<IExchangeRatesApiProxy>().Setup(r => r.ObterUltimaCotacaoMoeda("USD")).Returns(Task.FromResult(2M));

            //act
            var response = await app.ObterCotacaoMoeda(new Api.Model.Requests.ObterCotacaoMoedaRequest
            {
                IdCliente = 1,
                Moeda = Moeda.USD.ToString(),
                QuantidadeMoeda = 100
            });

            //assert
            Assert.Equal(220, response.ValorTotal);
        }

        [Fact(DisplayName = "Obter cotação de 100 dolares para um cliente inexistente. Deve possuir mensagens de erro.")]
        [Trait("Application", "ObterCotacao")]
        public async Task ObterCotacaoMoeda_ClienteInvalido_DeveRetornarMensagensDeErro()
        {
            //arrange
            var mocker = new AutoMocker();
            var app = mocker.CreateInstance<CotacaoApp>();
            mocker.CreateInstance<NotificacaoErro>();

            mocker.GetMock<IClienteRepository>().Setup(r => r.ObterClientePorId(0)).Returns(default(Cliente));

            //act
            var response = await app.ObterCotacaoMoeda(new Api.Model.Requests.ObterCotacaoMoedaRequest
            {
                IdCliente = 0,
                Moeda = Moeda.USD.ToString(),
                QuantidadeMoeda = 100
            });

            //assert
            Assert.True(mocker.GetMock<NotificacaoErro>().Object.PossuiMensangens);
        }

        [Fact(DisplayName = "Solicitar cotacao com quantidade de moeda igual a 0. Deve retornar mensagem de validação da quantidade de moeda")]
        [Trait("Application", "ObterCotacaoRequestValidation")]
        public void ObterCotacaoMoeda_QuantidadeMoedaIgualAZero_DeveRetornarMensagemDeValidacaoMoeda()
        {
            //arrange
            var mocker = new AutoMocker();
            var validador = mocker.CreateInstance<ObterCotacaoMoedaValidation>();
            mocker.GetMock<IClienteRepository>().Setup(r => r.ObterClientePorId(1)).Returns(new Cliente(1, "Teste", "12345678901", Domain.Enums.Segmento.Varejo));
            var request = new ObterCotacaoMoedaRequest()
            {
                IdCliente = 1,
                Moeda = Moeda.USD.ToString(),
                QuantidadeMoeda = 0
            };
            //act
            var valido = validador.Validar(request);

            //assert
            Assert.False(valido);
            Assert.Contains(mocker.GetMock<NotificacaoErro>().Object.Mensagens, m => m.Equals("Quantidade de moeda deve ser maior que 0"));
        }

        [Fact(DisplayName = "Solicitar cotacao com id do cliente igual a 0. Deve retornar mensagem de validação do id do cliente")]
        [Trait("Application", "ObterCotacaoRequestValidation")]
        public void ObterCotacaoMoeda_IdClienteInvalido_DeveRetornarMensagemDeValidacaoDoCodigoDeCliente()
        {
            //arrange
            var mocker = new AutoMocker();
            var validador = mocker.CreateInstance<ObterCotacaoMoedaValidation>();
            mocker.GetMock<IClienteRepository>().Setup(r => r.ObterClientePorId(0)).Returns(default(Cliente));
            var request = new ObterCotacaoMoedaRequest()
            {
                IdCliente = 0,
                Moeda = Moeda.USD.ToString(),
                QuantidadeMoeda = 100
            };
            //act
            var valido = validador.Validar(request);

            //assert
            Assert.False(valido);
            Assert.Contains(mocker.GetMock<NotificacaoErro>().Object.Mensagens, m => m.Equals("IdCliente deve ser maior que 0"));
        }

        [Fact(DisplayName = "Solicitar cotacao com id de cliente inexistente. Deve retornar mensagem de validação de cliente não encontrado")]
        [Trait("Application", "ObterCotacaoRequestValidation")]
        public void ObterCotacaoMoeda_CodigoDoClienteInexistente_DeveRetornarMensagemDeValidacaoDeClienteInexistente()
        {
            //arrange
            var mocker = new AutoMocker();
            var validador = mocker.CreateInstance<ObterCotacaoMoedaValidation>();
            mocker.GetMock<IClienteRepository>().Setup(r => r.ObterClientePorId(10)).Returns(default(Cliente));
            var request = new ObterCotacaoMoedaRequest()
            {
                IdCliente = 10,
                Moeda = Moeda.USD.ToString(),
                QuantidadeMoeda = 100
            };
            //act
            var valido = validador.Validar(request);

            //assert
            Assert.False(valido);
            Assert.Contains(mocker.GetMock<NotificacaoErro>().Object.Mensagens, m => m.Equals("Cliente não encontrado"));
        }

        [Fact(DisplayName = "Solicitar cotacao com moeda nula. Deve retornar mensagem de validação de moeda nula")]
        [Trait("Application", "ObterCotacaoRequestValidation")]
        public void ObterCotacaoMoeda_MoedaNula_DeveRetornarMensagemDeValidacaoDeMoedaNula()
        {
            //arrange
            var mocker = new AutoMocker();
            var validador = mocker.CreateInstance<ObterCotacaoMoedaValidation>();
            mocker.GetMock<IClienteRepository>().Setup(r => r.ObterClientePorId(10)).Returns(new Cliente(1, "Teste", "12345678901", Domain.Enums.Segmento.Varejo));
            var request = new ObterCotacaoMoedaRequest()
            {
                IdCliente = 10,
                Moeda = null,
                QuantidadeMoeda = 100
            };
            //act
            var valido = validador.Validar(request);

            //assert
            Assert.False(valido);
            Assert.Contains(mocker.GetMock<NotificacaoErro>().Object.Mensagens, m => m.Equals("Moeda não pode ser nula"));
        }

        [Fact(DisplayName = "Solicitar cotacao com moeda vazia. Deve retornar mensagem de validação de moeda vazia")]
        [Trait("Application", "ObterCotacaoRequestValidation")]
        public void ObterCotacaoMoeda_MoedaVazia_DeveRetornarMensagemDeValidacaoDeMoedaNula()
        {
            //arrange
            var mocker = new AutoMocker();
            var validador = mocker.CreateInstance<ObterCotacaoMoedaValidation>();
            mocker.GetMock<IClienteRepository>().Setup(r => r.ObterClientePorId(10)).Returns(new Cliente(1, "Teste", "12345678901", Domain.Enums.Segmento.Varejo));
            var request = new ObterCotacaoMoedaRequest()
            {
                IdCliente = 10,
                Moeda = string.Empty,
                QuantidadeMoeda = 100
            };
            //act
            var valido = validador.Validar(request);

            //assert
            Assert.False(valido);
            Assert.Contains(mocker.GetMock<NotificacaoErro>().Object.Mensagens, m => m.Equals("Moeda não pode ser vazia"));
        }

        [Fact(DisplayName = "Solicitar cotacao com moeda inválida. Deve retornar mensagem de validação de moeda inválida")]
        [Trait("Application", "ObterCotacaoRequestValidation")]
        public void ObterCotacaoMoeda_MoedaInvalida_DeveRetornarMensagemDeValidacaoDeMoedaInvalida()
        {
            //arrange
            var mocker = new AutoMocker();
            var validador = mocker.CreateInstance<ObterCotacaoMoedaValidation>();
            mocker.GetMock<IClienteRepository>().Setup(r => r.ObterClientePorId(10)).Returns(default(Cliente));
            var request = new ObterCotacaoMoedaRequest()
            {
                IdCliente = 10,
                Moeda = "A",
                QuantidadeMoeda = 100
            };
            //act
            var valido = validador.Validar(request);

            //assert
            Assert.False(valido);
            Assert.Contains(mocker.GetMock<NotificacaoErro>().Object.Mensagens, m => m.Equals("Moeda informada é inválida"));
        }
    }
}
