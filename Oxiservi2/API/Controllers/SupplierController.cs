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
    }
}
