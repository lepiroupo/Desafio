using Desafio.Domain.Entities;
using Desafio.Domain.Enums;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.Repository.Base;
using Microsoft.Extensions.Configuration;

namespace Desafio.Repository
{
    public class TaxaRepository : BaseRepository, ITaxaRepository
    {
        public TaxaRepository(IConfiguration configuration):base(configuration)
        {

        }
        public TaxaCambio ObterTaxaCambioPorSegmento(Segmento segmento)
        {
            var sql = $"SELECT IdSegmento, ValorTaxa " +
                      $"FROM dbo.TaxaCambio " +
                      $"WHERE IdSegmento = @segmento";

            var parametros = new { @segmento = (int)segmento };

            return ObterObjeto(sql, parametros,
                 row => new TaxaCambio(row.ValorTaxa));
        }
    }
}
