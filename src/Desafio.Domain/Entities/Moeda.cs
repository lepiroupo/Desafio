namespace Desafio.Domain.Entities
{
    public class Moeda
    {
        public string Nome { get; private set; }
        public decimal ValorEmReais { get; private set; }
        public Moeda(string nome, decimal valorEmReais)
        {
            Nome = nome;
            ValorEmReais = valorEmReais;
        }
    }
}
