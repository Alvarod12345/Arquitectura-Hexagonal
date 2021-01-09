using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.OxiServi.Commands.Movimiento;
using Application.OxiServi.Queries.Movimiento;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Movimiento")]
    public class MovimientoController : Controller
    {
        public IMovimientoQueries _movimientoQueries;
        public IMediator _mediator;
        public MovimientoController(IMovimientoQueries movimientoQueries,IMediator mediator)
        {

            _movimientoQueries = movimientoQueries;
            _mediator = mediator;
        }
        [HttpPost] // Post=Crear
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] CreateMovimientoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet]//Lista
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _movimientoQueries.GetAll();
            return Ok(result);
        }
        [HttpGet]
        [Route("GetMovimientoProducto")]
        public async Task<IActionResult> GetMovimientoProducto([FromQuery] ListarMovimientoViewModel listarParameter)
        {
            var result = await _movimientoQueries.GetMovimientoDetalle(listarParameter);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetMovimientoPaginado")]
        public async Task<IActionResult> GetAllPaginado([FromQuery] ListarMovimientoViewModel listarParameter)
        {
            var result = await _movimientoQueries.GetAllPaginado(listarParameter);
            return Ok(result);
        }
    }
}