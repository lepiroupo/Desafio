using Desafio.Domain.Entities;
using Desafio.Domain.Services;
using Xunit;

namespace Desafio.Tests.Services
{
    public class CotacaoMoedaServiceTests
    {
        [Fact(DisplayName ="Quantidade 100, Valor moeda 2, taxa 10%. Deve retornar 220")]
        [Trait("Domain", "CotacaoMoeda")]
        public void ObterCotacaoMoeda_100_ValorMoeda2_DeveRetornar220()
        {
            //arrange & act
            var valor = CotacaoMoedaService.ObterCotacao(new TaxaCambio(0.1M), 100, 2);
            //assert

            Assert.Equal(220M, valor);
        }
    }
}
