using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.OxiServi.Queries.Factura;
using Application.OxiServi.Commands.Factura;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Factura")]
    public class FacturaController : Controller
    {
        public IFacturaQueries _facturaQueries;
        public IMediator _mediator;

        public FacturaController(IFacturaQueries facturaQueries, IMediator mediator)
        {

            _facturaQueries = facturaQueries;
            _mediator = mediator;

        }
        [HttpGet]//Lista
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _facturaQueries.GetAll();
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllPagination")]
        public async Task<IActionResult> GetAllPaginado([FromQuery] ListarFacturaViewModel listarParameter)
        {
            var result = await _facturaQueries.GetAllPaginado(listarParameter);
            return Ok(result);
        }
        [HttpPut]
        [Route("UpdateEstado")]
        public async Task<IActionResult> UpdateEstado([FromBody]UpdateEstadoFacturaCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}