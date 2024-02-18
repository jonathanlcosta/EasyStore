using EasyStore.Clientes.API.Clientes.Commands;
using EasyStore.Clientes.API.Clientes.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyStore.Clientes.API.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly IMediator mediator;

        public ClientesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<ClienteResponse>> Inserir([FromBody] ClienteComando request)
        {
            var retorno = await mediator.Send(request);
            return Ok(retorno);
        }
    }
}