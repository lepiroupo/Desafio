using Desafio.Api.Model.Responses;
using Desafio.Domain.Entities;

namespace Desafio.App.Extensions
{
    public static class OperacaoExtension
    {
        public static ObterCotacaoMoedaResponse ToResponse(this OperacaoCambio operacao, decimal quantidadeMoedaEstrangeira)
        {
            return new ObterCotacaoMoedaResponse
            {
                Moeda = operacao.Moeda,
                Quantidade = quantidadeMoedaEstrangeira,
                ValorMoeda = operacao.ValorMoeda,
                ValorTotal = operacao.ValorOperacao
            };
        }
    }
}
