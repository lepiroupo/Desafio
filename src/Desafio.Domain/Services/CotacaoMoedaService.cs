using Desafio.Domain.Entities;

namespace Desafio.Domain.Services
{
    public class CotacaoMoedaService
    {
        public static decimal ObterCotacao(TaxaCambio taxaCambio, decimal quantidadeMoedaEstrangeira, decimal valorMoedaEstrangeira)
        {
            return quantidadeMoedaEstrangeira * valorMoedaEstrangeira * (1 + taxaCambio.ValorTaxa);
        }
    }
}
