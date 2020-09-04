using Desafio.Domain.Entities;

namespace Desafio.Domain.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        Cliente ObterClientePorId(long id);
    }
}
