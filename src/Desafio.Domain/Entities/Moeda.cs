using System;

namespace Desafio.Domain.Entities
{
    public class Moeda
    {
        public string Nome { get; private set; }
        public decimal ValorEmReais { get; private set; }
        public DateTime DataCotacao { get; private set; }
        public Moeda(string nome, decimal valorEmReais, string dataCotacao)
        {
            Nome = nome;
            ValorEmReais = valorEmReais;
            DataCotacao = DefinirDataCotacao(dataCotacao);
        }
        public Moeda(string nome, decimal valorEmReais, DateTime dataCotacao)
        {
            Nome = nome;
            ValorEmReais = valorEmReais;
            DataCotacao = dataCotacao;
        }

        private DateTime DefinirDataCotacao(string dataCotacao)
        {
            return DateTime.Parse(dataCotacao);
        }
    }
}
