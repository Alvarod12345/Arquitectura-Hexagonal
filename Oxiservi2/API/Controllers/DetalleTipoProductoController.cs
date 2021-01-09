using Application.OxiServi.Commands.DetalleTipoProducto;
using Application.OxiServi.Queries.DetalleTipoProducto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/DetalleTipoProducto")]
    public class DetalleTipoProductoController : Controller
    {
        public IMediator _mediator;
        public IDetalleTipoProductoQueries _detalleTipoProductoQueries;
        public DetalleTipoProductoController(IDetalleTipoProductoQueries detalleTipoProductoQueries, IMediator mediator)
        {
            _detalleTipoProductoQueries = detalleTipoProductoQueries;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("CreateDetalle")]
        public async Task<IActionResult> CreateDetalle([FromBody] CreateDetalleTipoProductoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllPagination")]
        public async Task<IActionResult> GetAllPagination([FromQuery]filterDetalleTipoProductoViewModel filter)
        {
            var result = await _detalleTipoProductoQueries.GetAllPagination(filter);
            return Ok(result);
        }

        [HttpPut] //put = actualizar
        [Route("Desactivar")]
        public async Task<IActionResult> Desactivar([FromBody]DesactivarDetalleTipoProductoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut] //put = actualizar
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromBody]DeleteDetalleTipoProductoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
