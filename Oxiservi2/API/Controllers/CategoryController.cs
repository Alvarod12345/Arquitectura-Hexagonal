using Application.Northwind.Commands.Category;
using Application.Northwind.Queries.Category;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Category")]
    public class CategoryController :  ControllerBase
    {
        public ICategoryQueries _categoryQueries;
        public IMediator _mediator;
        
        public CategoryController(ICategoryQueries categoryQueries, IMediator mediator)
        {
            _categoryQueries = categoryQueries;
            _mediator = mediator;
        }

        [HttpGet]//Lista
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _categoryQueries.GetAll();
            return Ok(result);
        }

        [HttpPost]//Crear
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]//Actualizar
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]//Crear
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
