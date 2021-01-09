    using System;
using System.Threading.Tasks;
using Application.OxiServi.Commands.Direccion;
using Application.OxiServi.Queries.Direccion;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Direccion")]
    public class DireccionController : Controller
    {
        public IMediator _mediator;
        public IDireccionQueries _direccionQueries;
        public DireccionController(IMediator mediator, IDireccionQueries direccionQueries)
        {
            _mediator = mediator;
            _direccionQueries = direccionQueries;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _direccionQueries.GetAll();
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllByIdCliente")]
        public async Task<IActionResult> GetAllByIdCliente([FromQuery]int idCliente)
        {
            var result = await _direccionQueries.GetAllByCliente(idCliente);
            return Ok(result);
        }
        [HttpPost]
        [Route("CreateDireccion")] 
        public async Task<IActionResult> CreateDireccion([FromBody]CreateDireccionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPost]
        [Route("ActiveDireccion")]
        public async Task<IActionResult> ActiveDireccion([FromBody]ActiveDireccionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}