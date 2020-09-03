using Desafio.Domain.Entities;
using Desafio.Domain.Enums;
using System.Collections.Generic;

namespace Desafio.Domain.Interfaces.Repositories
{
    public interface ITaxaRepository
    {
        TaxaCambio ObterTaxaCambioPorSegmento(Segmento segmento);
        IEnumerable<TaxaCambio> ListarTaxasCambio();
        void AtualizarTaxaCambio(TaxaCambio taxaCambio);
    }
}
