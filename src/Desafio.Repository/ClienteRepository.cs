using Desafio.Domain.Entities;
using Desafio.Domain.Enums;
using Desafio.Domain.Interfaces.Repositories;

namespace Desafio.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        public Cliente ObterClientePorId(long id)
        {
            return new Cliente(id, "Teste", "12345678901", Segmento.Varejo);
        }
    }
}
