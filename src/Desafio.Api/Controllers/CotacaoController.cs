using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio.App.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CotacaoController : ControllerBase
    {
        private readonly ICotacaoApp _app;

        public CotacaoController(ICotacaoApp app)
        {
            _app = app;
        }

        [HttpGet]
        public async Task<JsonResult> ObterCotacaoMoeda(long idCliente, string moeda, decimal quantidadeMoeda)
        {
            return new JsonResult(await _app.ObterCotacaoMoedaCliente(idCliente, moeda, quantidadeMoeda));
        }
    }
}
