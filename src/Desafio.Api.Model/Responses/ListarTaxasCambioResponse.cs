using Desafio.Api.Model.Enums;

namespace Desafio.Api.Model.Responses
{
    public class ListarTaxasCambioResponse
    {
        public Segmento Segmento { get; set; }
        public decimal ValorTaxa { get; set; }
    }
}
