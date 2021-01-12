using Application.Northwind.Commands.Supplier;
using Application.OxiServi.Commands.Supplier;
using Application.OxiServi.Queries.Base;
using Application.OxiServi.Queries.Supplier;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Supplier")]
    public class SupplierController : ControllerBase
    {
        public ISupplierQueries _supplierQueries;
        public IMediator _mediator;
        public SupplierController(ISupplierQueries providerQueries, IMediator mediator)
        {
            _supplierQueries = providerQueries;
            _mediator = mediator;
        }
        [HttpGet]//Lista
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _supplierQueries.GetAll();
            return Ok(result);
        }

        [HttpPost]//Crear
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] CreateSupplierCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]//Crear
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateSupplierCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]//Crear
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteSupplierCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
