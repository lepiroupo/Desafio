using Desafio.Api.Model.Enums;

namespace Desafio.Api.Model.Requests
{
    public class AtualizarTaxaCambioRequest
    {
        public decimal ValorTaxa { get; set; }
        public Segmento Segmento { get; set; }
    }
}
