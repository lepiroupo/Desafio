using Desafio.Api.Model.Enums;
using Desafio.Api.Model.Responses;
using Desafio.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Desafio.App.Extensions
{
    public static class TaxaCambioExtensions
    {
        public static IEnumerable<ListarTaxasCambioResponse> ToResponse(this IEnumerable<TaxaCambio> taxas)
        {
            return taxas.Select(t => new ListarTaxasCambioResponse()
            {
                Segmento = (Segmento)t.Segmento,
                ValorTaxa = t.ValorTaxa
            });

        }
    }
}
