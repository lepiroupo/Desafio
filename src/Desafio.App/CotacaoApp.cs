﻿using Desafio.App.Interfaces;
using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.ExchangeRates.Proxy.Interfaces;
using System.Threading.Tasks;

namespace Desafio.App
{
    public class CotacaoApp : ICotacaoApp
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ITaxaRepository _taxaRepository;
        private readonly IExchangeRatesApiProxy _exchangeRatesApiProxy;

        public CotacaoApp(IClienteRepository clienteRepository, ITaxaRepository taxaRepository, IExchangeRatesApiProxy exchangeRatesApiProxy)
        {
            _clienteRepository = clienteRepository;
            _taxaRepository = taxaRepository;
            _exchangeRatesApiProxy = exchangeRatesApiProxy;
        }

        public async Task<decimal> ObterCotacaoMoedaCliente(long idCliente, string descricaoMoeda, decimal quantidadeMoedaEstrangeira)
        {
            var cliente = _clienteRepository.ObterClientePorId(idCliente);
            var taxa = _taxaRepository.ObterTaxaCambioPorSegmento(cliente.Segmento);
            var moeda = await _exchangeRatesApiProxy.ObterUltimaCotacaoMoeda(descricaoMoeda);

            var operacao = new OperacaoCambio(cliente, taxa, moeda);

            return operacao.ObterValorOperacao(quantidadeMoedaEstrangeira);
        }
    }
}
