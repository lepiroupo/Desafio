using Desafio.Api.Model.Requests;
using Desafio.Api.Model.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.App.Interfaces
{
    public interface ITaxaApp
    {
        Task<IEnumerable<ListarTaxasCambioResponse>> ListarTaxasCambio();
        Task AtualizarTaxaCambio(AtualizarTaxaCambioRequest request);
    }
}
