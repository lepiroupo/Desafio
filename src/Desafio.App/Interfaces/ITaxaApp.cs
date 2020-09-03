using Desafio.Api.Model.Requests;
using Desafio.Api.Model.Responses;
using System.Collections.Generic;

namespace Desafio.App.Interfaces
{
    public interface ITaxaApp
    {
        IEnumerable<ListarTaxasCambioResponse> ListarTaxasCambio();
        void AtualizarTaxaCambio(AtualizarTaxaCambioRequest request);
    }
}
