using Desafio.Api.Model.Requests;
using Desafio.Api.Model.Responses;
using Desafio.App.Extensions;
using Desafio.App.Interfaces;
using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.App
{
    public class TaxaApp : ITaxaApp
    {
        private readonly ITaxaRepository _taxaRepository;

        public TaxaApp(ITaxaRepository taxaRepository)
        {
            _taxaRepository = taxaRepository;
        }

        public Task AtualizarTaxaCambio(AtualizarTaxaCambioRequest request)
        {
            return Task.Run(() => _taxaRepository.AtualizarTaxaCambio(new TaxaCambio((Domain.Enums.Segmento)request.Segmento, request.ValorTaxa)));
        }
        public Task<IEnumerable<ListarTaxasCambioResponse>> ListarTaxasCambio()
        {
            var taxas = _taxaRepository.ListarTaxasCambio();
            return Task.FromResult(taxas.ToResponse());
        }
    }
}
