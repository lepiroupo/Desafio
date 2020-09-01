using Desafio.Domain.Enums;

namespace Desafio.Domain.Entities
{
    public class Cliente
    {
        public long Id { get; private set; }
        public string Nome { get; private set; }
        public string CpfCnpj { get; private set; }
        public Segmento Segmento { get; private set; }
        public Cliente(long codigoCliente, string nome, string cpfCnpj, Segmento segmento)
        {
            Id = codigoCliente;
            Nome = nome;
            CpfCnpj = cpfCnpj;
            Segmento = segmento;
        }
    }
}
