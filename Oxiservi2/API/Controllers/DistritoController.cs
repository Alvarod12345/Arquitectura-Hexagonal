using Application.OxiServi.Commands.Distrito;
using Application.OxiServi.Queries.Distrito;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Distrito")]
    public class DistritoController:Controller
    {
        public IMediator _mediator;
        public IDistritoQueries _distritoQueries;
        public DistritoController(IDistritoQueries distritoQueries,IMediator mediator)
        {
            _distritoQueries = distritoQueries;
            _mediator = mediator;
        }

        [HttpPost]//Crear
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] CreateDistritoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllPagination")]
        public async Task<IActionResult> GetAllPagination([FromQuery]filterDistritoViewModel filter)
        {
            var result = await _distritoQueries.GetAllPagination(filter);
            return Ok(result);
        }
        [HttpPut]
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteDistritoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut]
        [Route("Desactive")]
        public async Task<IActionResult> Desactive([FromBody] DesactivateDistritoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
