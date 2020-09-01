using Desafio.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Desafio.Tests.Repositories
{
    public class ClienteRepositoryTests
    {
        [Fact(DisplayName ="Obter o cliente por Id. Deve retornar cliente.")]
        [Trait("Repository", "Cliente")]
        public void ObterClientePorId_DeveRetornarCliente()
        {
            //arrange
            var repository = new ClienteRepository();

            //act
            var cliente = repository.ObterClientePorId(1);

            //assert
            Assert.NotNull(cliente);
        }
    }
}
