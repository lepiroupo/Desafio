using Desafio.Domain.Enums;

namespace Desafio.Domain.Entities
{
    public class Cliente
    {
        public long IdCliente { get; private set; }
        public string NomeCliente { get; private set; }
        public string CpfCnpj { get; private set; }
        public Segmento Segmento { get; private set; }
        public Cliente(long idCliente, string nomeCliente, string cpfCnpj, Segmento segmento)
        {
            IdCliente = idCliente;
            NomeCliente = nomeCliente;
            CpfCnpj = cpfCnpj;
            Segmento = segmento;
        }
    }
}
