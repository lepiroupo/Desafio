using Desafio.Api.Model.Requests;
using Desafio.Api.Model.Responses;
using Desafio.App.Extensions;
using Desafio.App.Interfaces;
using Desafio.App.Validation;
using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.ExchangeRates.Proxy.Interfaces;
using Desafio.Message.Notifications;
using System.Threading.Tasks;

namespace Desafio.App
{
    public class CotacaoApp : ICotacaoApp
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ITaxaRepository _taxaRepository;
        private readonly IExchangeRatesApiProxy _exchangeRatesApiProxy;
        private readonly NotificacaoErro _notificacoes;

        public CotacaoApp(IClienteRepository clienteRepository, ITaxaRepository taxaRepository, IExchangeRatesApiProxy exchangeRatesApiProxy, NotificacaoErro notificacoes)
        {
            _clienteRepository = clienteRepository;
            _taxaRepository = taxaRepository;
            _exchangeRatesApiProxy = exchangeRatesApiProxy;
            _notificacoes = notificacoes;
        }

        public async Task<ObterCotacaoMoedaResponse> ObterCotacaoMoeda(ObterCotacaoMoedaRequest request)
        {
            if (new ObterCotacaoMoedaValidation(_clienteRepository, _notificacoes).Validar(request))
            {
                var cliente = _clienteRepository.ObterClientePorId(request.IdCliente);
                var taxa = _taxaRepository.ObterTaxaCambioPorSegmento(cliente.Segmento);
                var valorMoeda = await _exchangeRatesApiProxy.ObterUltimaCotacaoMoeda(request.Moeda);

                var operacao = new OperacaoCambio(cliente, taxa);

                operacao.DefinirMoedaOperacao(request.Moeda, valorMoeda);

                operacao.CalcularValorOperacao(request.QuantidadeMoeda);

                return operacao.ToResponse(request.QuantidadeMoeda);
            }
            return null;
        }
    }
}
