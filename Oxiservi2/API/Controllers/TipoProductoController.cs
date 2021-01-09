using Application.OxiServi.Commands.TipoProducto;
using Application.OxiServi.Queries.TipoProducto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/TipoProducto")]
    public class TipoProductoController:Controller
    {
        public IMediator _mediator;
        public ITipoProductoQueries _tipoproductoQueries;
        public TipoProductoController(ITipoProductoQueries tipoproductoQueries, IMediator mediator)
        {
            _tipoproductoQueries = tipoproductoQueries;
            _mediator = mediator;
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] CreateTipoProductoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllPagination")]
        public async Task<IActionResult> GetAllPagination([FromQuery]filterTipoProductoViewModel filter)
        {
            var result = await _tipoproductoQueries.GetAllPagination(filter);
            return Ok(result);
        }
        [HttpPut]
        [Route("Desactive")]
        public async Task<IActionResult> Desactive([FromBody] DesactivateTipoProductoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut]
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteTipoProductoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
