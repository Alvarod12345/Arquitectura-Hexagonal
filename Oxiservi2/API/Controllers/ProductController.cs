using Application.Northwind.Commands.Product;
using Application.Northwind.Queries.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Product")]
    public class ProductController : ControllerBase
    {
        public IProductQueries _productQueries;
        public IMediator _mediator;
        public ProductController(IProductQueries productQueries, IMediator mediator)
        {
            _productQueries = productQueries;
            _mediator = mediator;
        }

        [HttpGet]//Lista
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productQueries.GetAll();
            return Ok(result);
        }

        [HttpPost]//Crear
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] CreateProductCommad command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]//Actualizar
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]//Delete
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteProductCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
