using System.Text.Json.Serialization;

namespace Desafio.ExchangeRates.Proxy.Model
{
    class LatestResult
    {
        [JsonPropertyName("rates")]
        public Rates Rates { get; set; }
        [JsonPropertyName("base")]
        public string Base { get; set; }
        [JsonPropertyName("date")]
        public string Date { get; set; }
    }
}
