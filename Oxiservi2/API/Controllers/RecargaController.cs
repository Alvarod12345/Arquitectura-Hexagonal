using System.Threading.Tasks;
using Application.OxiServi.Commands.Recarga;
using Application.OxiServi.Queries.Recarga;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Recarga")]
    public class RecargaController : ControllerBase
    {
        public IMediator _mediator;
        public IRecargaQueries _recargaQueries;
        public RecargaController(IMediator mediator, IRecargaQueries recargaQueries)
        {
            _mediator = mediator;
            _recargaQueries = recargaQueries;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _recargaQueries.GetAll();
            return Ok(result);
        }
        [HttpGet]
        [Route("GetNoAtendido")]
        public async Task<IActionResult> GetNoAtendidas()
        {
            var result = await _recargaQueries.GetNoAtendidas();
            return Ok(result);
        }
        [HttpGet]
        [Route("GetRecargaById")]
        public async Task<IActionResult> GetRecargaById([FromQuery] int idRecarga)
        {
            var result = await _recargaQueries.GetRecargaById(idRecarga);
            return Ok(result);
        }
        [HttpPut]
        [Route("GenerarRecarga")]
        public async Task<IActionResult> GenerarRecarga([FromBody] GenerarRecargaCommand command)
        {
            var result = await _mediator.Send(command);
            //BadRequest();
            return Ok(result);
        }
        [HttpPost]
        [Route("AtenderRecarga")]
        public async Task<IActionResult> AtenderRecarga([FromBody] AtenderRecargaCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPost]
        [Route("DeleteProductoRecarga")]
        public async Task<IActionResult> DeleteProductoRecarga([FromBody] DeleteProductoRecargaCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}