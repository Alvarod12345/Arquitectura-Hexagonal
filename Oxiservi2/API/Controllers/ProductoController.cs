using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.OxiServi.Commands.Producto;
using Application.OxiServi.Queries.Producto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Producto")]
    public class ProductoController : Controller
    {
        public IMediator _mediator;
        public IProductoQueries _queries;
        public ProductoController(IMediator mediator,IProductoQueries productoQueries)
        {
            _mediator = mediator;
            _queries = productoQueries;
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] CreateProductoCommand command)
        {
            var result = await _mediator.Send(command);
            switch (result)
            {
                case -1: return BadRequest(new { message = "El numero de serie se encuentra en uso." });
            }
            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateProducto")]
        public async Task<IActionResult> UpdateProducto([FromBody] UpdateProductoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get()
        {
            var result = await _queries.GetAll();
            return Ok(result);
        }
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetAllById([FromQuery] ListarProductoByIdParametro pr)
        {
            var result = await _queries.GetAllById(pr);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetTipoProducto")]
        public async Task<IActionResult> GetTipoProducto()
        {
            var result = await _queries.GetTipoProducto();
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllPagination")]
        public async Task<IActionResult> GetAllPagination([FromQuery] ListarFiltroProductoViewModel filter)
        {
            var result = await _queries.GetAllPaginado(filter);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAutocomplete")]
        public async Task<IActionResult> GetAutocomplete([FromQuery] string query)
        {
            var result = await _queries.GetAutocomplete(query);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetProductoRecarga")]
        public async Task<IActionResult> GetProductoRecarga([FromQuery] string query)
        {
            var result = await _queries.GetProductoRecarga(query);
            return Ok(result);
        }
        [HttpPost]
        [Route("RequestValidateSerie")]
        public async Task<IActionResult> RequestValidateSerie([FromBody]RequestValidateSerieCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut]
        [Route("DesactivarProducto")]
        public async Task<IActionResult> DesactivarProducto([FromBody]DesactivarProductoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        
    }
}