using System.Collections.Generic;
using System.Threading.Tasks;
using Desafio.Api.Model.Enums;
using Desafio.Api.Model.Requests;
using Desafio.Api.Model.Responses;
using Desafio.App.Interfaces;
using Desafio.Message.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Desafio.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CotacaoController : BaseController
    {
        private readonly ICotacaoApp _app;

        public CotacaoController(ICotacaoApp app, NotificacaoErro notificacaoErro):base(notificacaoErro)
        {
            _app = app;
        }

        [HttpGet]
        [Route("ObterCotacaoMoeda")]
        [SwaggerOperation("Obtém a cotação de moeda para o cliente informado")]
        [SwaggerResponse(StatusCodes.Status200OK, "Cotação realizada com sucesso", typeof(ObterCotacaoMoedaResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Erro no processamento da cotação", typeof(IEnumerable<string>))]
        [Produces("application/json")]
        public async Task<IActionResult> ObterCotacaoMoeda(long idCliente, Moeda? moeda, decimal quantidadeMoeda)
        {
            var request = new ObterCotacaoMoedaRequest
            {
                IdCliente = idCliente,
                Moeda = moeda.ToString(),
                QuantidadeMoeda = quantidadeMoeda
            };
            return await ProcessarRequest(() => _app.ObterCotacaoMoeda(request));

        }
    }
}
