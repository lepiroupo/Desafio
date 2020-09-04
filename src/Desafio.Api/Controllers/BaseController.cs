using System;
using System.Threading.Tasks;
using Desafio.Message.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly NotificacaoErro _notificacoes;

        public BaseController(NotificacaoErro notificacoes)
        {
            _notificacoes = notificacoes;
        }

        protected async Task<IActionResult> ProcessarRequest<T>(Func<Task<T>> metodo)
        {
            T response = default;
            try
            {
                response = await metodo();
            }
            catch (Exception ex)
            {
                _notificacoes.AdicionarMensangem(ex.Message);
            }

            if (_notificacoes.PossuiMensangens)
                return BadRequest(_notificacoes.Mensagens);

            return new JsonResult(response);
        }
        protected async Task<IActionResult> ProcessarRequest(Func<Task> metodo)
        {
            try
            {
                await metodo();
            }
            catch (Exception ex)
            {
                _notificacoes.AdicionarMensangem(ex.Message);
            }

            if (_notificacoes.PossuiMensangens)
                return BadRequest(_notificacoes.Mensagens);

            return Ok();
        }
    }
}
