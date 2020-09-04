namespace Desafio.Api.Model.Requests
{
    public class ObterCotacaoMoedaRequest
    {
        public decimal QuantidadeMoeda { get; set; }
        public long IdCliente { get; set; }
        public string Moeda { get; set; }
    }
}
