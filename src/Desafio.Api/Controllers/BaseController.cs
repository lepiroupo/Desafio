using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected async Task<IActionResult> ProcessarRequest<T>(Func<Task<T>> metodo)
        {
            try
            {
                var response = await metodo();
                return new JsonResult(response);
            }
            catch (Exception)
            {
                //gravar exception 
                return BadRequest();
            }
        }

        private IActionResult BadRequest()
        {
            return new BadRequestResult();
        }
    }
}
