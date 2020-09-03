using System.Threading.Tasks;
using Desafio.Api.Model.Enums;
using Desafio.Api.Model.Responses;
using Desafio.App.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CotacaoController : BaseController
    {
        private readonly ICotacaoApp _app;

        public CotacaoController(ICotacaoApp app)
        {
            _app = app;
        }
        /// <summary>
        /// Obtém a cotação de moeda para o cliente informado
        /// </summary>
        /// <param name="idCliente"></param>
        /// <param name="moeda"></param>
        /// <param name="quantidadeMoeda"></param>
        /// <returns></returns>
        /// <response code="200">Cotação executada com sucesso</response>
        /// <response code="400">Cliente inválido</response> 
        [HttpGet]
        [Route("ObterCotacaoMoeda")]
        [ProducesResponseType(typeof(ObterCotacaoMoedaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<IActionResult> ObterCotacaoMoeda(long idCliente, Moeda moeda, decimal quantidadeMoeda)
        {
            return await ProcessarRequest(() => _app.ObterCotacaoMoeda(idCliente, moeda.ToString(), quantidadeMoeda));

        }
    }
}
