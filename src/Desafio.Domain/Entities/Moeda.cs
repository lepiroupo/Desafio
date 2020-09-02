using System;

namespace Desafio.Domain.Entities
{
    public class Moeda
    {
        public string Nome { get; set; }
        public decimal ValorEmReais { get; set; }
        public DateTime DataCotacao { get; set; }
        public Moeda(string nome, decimal valorEmReais, string dataCotacao)
        {
            Nome = nome;
            ValorEmReais = valorEmReais;
            DataCotacao = DefinirDataCotacao(dataCotacao);
        }
        protected Moeda()
        {
        }
        private DateTime DefinirDataCotacao(string dataCotacao)
        {
            return DateTime.Parse(dataCotacao);
        }
    }
}
