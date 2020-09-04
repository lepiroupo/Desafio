using Desafio.Domain.Entities;
using Desafio.Domain.Enums;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.Repository.Base;
using Microsoft.Extensions.Configuration;

namespace Desafio.Repository
{
    public class ClienteRepository : BaseRepository, IClienteRepository
    {

        public ClienteRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public Cliente ObterClientePorId(long id)
        {
            var sql = $"SELECT IdCliente, NomeCliente, CpfCnpj, IdSegmento FROM dbo.Cliente WHERE IdCliente = @idCliente";

            var parametros = new { idCliente = id };

            return ObterObjeto(sql, parametros,
                 row => new Cliente((long)row.IdCliente, (string)row.NomeCliente, (string)row.CpfCnpj, (Segmento)row.IdSegmento));            
        }
    }
}
