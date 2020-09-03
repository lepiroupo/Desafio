using Desafio.Api.Model.Enums;
using Desafio.Domain.Entities;
using Desafio.Domain.Enums;
using System;
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
            var operacaoCambio = new OperacaoCambio(new Cliente(1, "Teste", "012345678901", Domain.Enums.Segmento.Varejo), new TaxaCambio(Domain.Enums.Segmento.Varejo, 0.1M));

            //act
            operacaoCambio.DefinirMoedaOperacao("USD", 2m);
            operacaoCambio.CalcularValorOperacao(100);

            //assert
            Assert.Equal(220, operacaoCambio.ValorOperacao);
        }
    }
}
