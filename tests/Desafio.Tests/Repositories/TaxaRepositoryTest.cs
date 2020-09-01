using Desafio.Domain.Enums;
using Desafio.Repository;
using Xunit;

namespace Desafio.Tests.Repositories
{
    public class TaxaRepositoryTest
    {
        [Fact(DisplayName ="Obter Taxas de Câmbio. Deve retornar as taxas por segmento.")]
        [Trait("Repository", "Taxa")]
        public void ObterTaxas_DeveRetornarTaxasPorSegmento()
        {
            //arrange
            var repository = new TaxaRepository();

            //act
            var taxa = repository.ObterTaxaCambioPorSegmento(Segmento.Varejo);

            //assert
            Assert.NotNull(taxa);
        }
    }
}
