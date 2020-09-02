using Desafio.Domain.Entities;
using Desafio.Domain.Enums;
using Xunit;

namespace Desafio.Tests.Entities
{
    public class OperacaoCambioTest
    {
        [Fact(DisplayName = "Obter cotação de 100 dolares em reais, com taxa de 10%. Deve Retornar 220.")]
        [Trait("Entity", "OperacaoCambio")]
        public void OperacaoCambio_ObterValorCotacao()
        {
            //arrange
            var operacaoCambio = new OperacaoCambio(new Cliente(1, "Teste", "012345678901", Segmento.Varejo), new TaxaCambio(0.1M), new Moeda("USD", 2M, "2020-08-31"));

            //act
            var valorOperacao = operacaoCambio.ObterValorOperacao(100);

            //assert
            Assert.Equal(220, valorOperacao);
        }
    }
}
