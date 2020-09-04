using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Desafio.Api.Model.Requests;
using Desafio.Api.Model.Responses;
using Desafio.App.Interfaces;
using Desafio.Message.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Desafio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxaController : BaseController
    {
        private ITaxaApp _taxaApp;

        public TaxaController(ITaxaApp taxaApp, NotificacaoErro notificacoes) : base(notificacoes)
        {
            _taxaApp = taxaApp;
        }
        /// <summary>
        /// Lista todas as taxas de câmbio
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ObterTaxasCambio")]
        [SwaggerOperation("Lista todas as taxas de câmbio")]
        [SwaggerResponse(StatusCodes.Status200OK, "Taxas listadas com suceso", typeof(IEnumerable<ListarTaxasCambioResponse>))]
        [Produces("application/json")]
        public async Task<IActionResult> ListarTaxasCambio()
        {
            return await ProcessarRequest(() => _taxaApp.ListarTaxasCambio());
        }

        /// <summary>
        /// Atualiza o valor da taxa de câmbio do segmento
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("AtualizarTaxaCambio")]
        [SwaggerOperation("Atualiza o valor da taxa de câmbio do segmento")]
        [SwaggerResponse(StatusCodes.Status200OK, "Taxa Atualizada")]
        public async Task<IActionResult> AtualizarTaxaCambio(AtualizarTaxaCambioRequest request)
        {
            return await ProcessarRequest(() => _taxaApp.AtualizarTaxaCambio(request));
        }
    }
}
