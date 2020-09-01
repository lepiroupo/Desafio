using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.App.Interfaces
{
    public interface ICotacaoApp
    {
        Task<decimal> ObterCotacaoMoedaCliente(long idCliente, string descricaoMoeda, decimal quantidadeMoedaEstrangeira);
    }
}
