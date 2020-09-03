using System.Threading.Tasks;
using Desafio.Api.Model.Requests;
using Desafio.Api.Model.Responses;
using Desafio.App.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxaController : ControllerBase
    {
        private ITaxaApp _taxaApp;

        public TaxaController(ITaxaApp taxaApp)
        {
            _taxaApp = taxaApp;
        }
        /// <summary>
        /// Lista todas as taxas de câmbio
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ObterTaxasCambio")]
        [ProducesResponseType(typeof(ListarTaxasCambioResponse), StatusCodes.Status200OK)]
        [Produces("application/json")]
        public Task<JsonResult> ListarTaxasCambio()
        {
            return Task.FromResult(new JsonResult(_taxaApp.ListarTaxasCambio()));
        }

        /// <summary>
        /// Atualiza o valor da taxa de câmbio do segmento
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("AtualizarTaxaCambio")]
        public Task AtualizarTaxaCambio(AtualizarTaxaCambioRequest request)
        {
            return Task.Run(() =>_taxaApp.AtualizarTaxaCambio(request));
        }
    }
}
