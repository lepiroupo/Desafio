using Desafio.Domain.Entities;
using Desafio.Domain.Enums;

namespace Desafio.Domain.Interfaces.Repositories
{
    public interface ITaxaRepository
    {
        TaxaCambio ObterTaxaCambioPorSegmento(Segmento segmento);
    }
}
