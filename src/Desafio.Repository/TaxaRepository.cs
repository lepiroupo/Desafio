using Desafio.Domain.Entities;
using Desafio.Domain.Enums;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.Repository.Base;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Desafio.Repository
{
    public class TaxaRepository : BaseRepository, ITaxaRepository
    {
        public TaxaRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public IEnumerable<TaxaCambio> ListarTaxasCambio()
        {
            var sql = $"SELECT IdTaxaCambio, IdSegmento, ValorTaxa " +
                      $"FROM dbo.TaxaCambio";

            return ObterLista(sql, GerarTaxa());
        }

        public TaxaCambio ObterTaxaCambioPorSegmento(Segmento segmento)
        {
            var sql = $"SELECT IdTaxaCambio, IdSegmento, ValorTaxa " +
                      $"FROM dbo.TaxaCambio " +
                      $"WHERE IdSegmento = @segmento";

            var parametros = new { @segmento = (int)segmento };

            return ObterObjeto(sql, parametros, GerarTaxa());
        }

        public void AtualizarTaxaCambio(TaxaCambio taxaCambio)
        {
            var sql = "UPDATE dbo.TaxaCambio SET ValorTaxa = @valorTaxa WHERE IdSegmento = @segmento";
            var parametros = new { @valorTaxa = taxaCambio.ValorTaxa, @segmento = (int)taxaCambio.Segmento };
            ExecutarConsultaSemRetorno(sql, parametros);
        }

        private static System.Func<dynamic, TaxaCambio> GerarTaxa()
        {
            return row => new TaxaCambio((Segmento)row.IdSegmento, row.ValorTaxa);
        }
    }
}
