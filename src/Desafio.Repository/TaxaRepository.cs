using Desafio.Domain.Entities;
using Desafio.Domain.Enums;
using Desafio.Domain.Interfaces.Repositories;

namespace Desafio.Repository
{
    public class TaxaRepository : ITaxaRepository
    {
        public TaxaCambio ObterTaxaCambioPorSegmento(Segmento segmento)
        {
            return new TaxaCambio(0.5M);
        }
    }
}
