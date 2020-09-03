using System;

namespace Desafio.ExchangeRates.Proxy.Dtos
{
    public class MoedaDto
    {
        public string Nome { get; set; }
        public decimal ValorEmReais { get; set; }
        public DateTime DataCotacao { get; set; }
        public MoedaDto(string nome, decimal valorEmReais, string dataCotacao)
        {
            Nome = nome;
            ValorEmReais = valorEmReais;
            DefinirDataCotacao(dataCotacao);
        }
        public MoedaDto()
        {

        }
        private void DefinirDataCotacao(string dataCotacao)
        {
            DataCotacao = DateTime.Parse(dataCotacao);
        }

    }
}
