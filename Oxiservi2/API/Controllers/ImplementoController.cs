using Application.OxiServi.Commands.Implemento;
using Application.OxiServi.Queries.Implemento;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Implemento")]
    public class ImplementoController:Controller
    {
        public IMediator _mediator;
        public IImplementoQueries _implementoQueries;
        public ImplementoController(IImplementoQueries implementoQueries,IMediator mediator)
        {
            _implementoQueries = implementoQueries;
            _mediator = mediator;
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] CreateImplementoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllPagination")]
        public async Task<IActionResult> GetAllPagination([FromQuery]filterImplementoViewModel filter)
        {
            var result = await _implementoQueries.GetAllPagination(filter);
            return Ok(result);
        }
        [HttpPut]
        [Route("Desactive")]
        public async Task<IActionResult> Desactive([FromBody] DesactivateImplementoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut]
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteImplementoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
