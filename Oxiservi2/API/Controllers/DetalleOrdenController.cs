using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.OxiServi.Commands.DetalleOrden;
using Application.OxiServi.Queries.DetalleOrden;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/DetalleOrden")]
    public class DetalleOrdenController : Controller
    {
        public IMediator _mediator;
        public IDetalleOrdenQueries _detalleOrdenQueries;
        public DetalleOrdenController(IMediator mediator, IDetalleOrdenQueries detalleOrdenQueries)
        {
            _mediator = mediator;
            _detalleOrdenQueries = detalleOrdenQueries;
        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody]DetalleOrdenCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllPagination")]
        public async Task<IActionResult> GetAllPagination([FromQuery]FilterDetalleOrdenViewModel filter)
        {
            var result = await _detalleOrdenQueries.GetAllPagination(filter);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetDetalleOrdenByIdMobile")]
        public async Task<IActionResult> GetDetalleOrdenByIdMobile([FromQuery]int idOrden)
        {
            var result = await _detalleOrdenQueries.GetDetalleOrdenByIdOrdenMobile(idOrden);
            return Ok(result);
        }
        [HttpPut]
        [Route("UpdateDetalleOrden")]
        public async Task<IActionResult> UpdateDetalleOrden([FromBody] DetalleOrdenEstadoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut]
        [Route("DevolverProducto")]
        public async Task<IActionResult> DevolverProducto([FromBody]DevolverProductoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}