using System;

namespace Desafio.ExchangeRates.Proxy.Dtos
{
    public class MoedaDto
    {
        public string Nome { get; set; }
        public decimal ValorEmReais { get; set; }
        public DateTime DataCotacao { get; set; }
    }
}
