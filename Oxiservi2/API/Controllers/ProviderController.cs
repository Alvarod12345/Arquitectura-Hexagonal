using Application.OxiServi.Commands.Provider;
using Application.OxiServi.Queries.Base;
using Application.OxiServi.Queries.Provider;
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
    [Route("api/Provider")]
    public class ProviderController : ControllerBase
    {
        public IProviderQueries _providerQueries;
        public IMediator _mediator;
        public ProviderController(IProviderQueries providerQueries, IMediator mediator)
        {
            _providerQueries = providerQueries;
            _mediator = mediator;
        }
        [HttpGet]//Lista
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _providerQueries.GetAll();
            return Ok(result);
        }
        //[HttpGet]//Lista busqueda por nombre
        //[Route("GetProveedorByName")]
        //public async Task<IActionResult> GetAllByNames([FromQuery] ListarProviderByNamesParameter namepr)
        //{
        //    var result = await _providerQueries.GetProviderByNames(namepr);
        //    return Ok(result);
        //}
        [HttpGet]
        [Route("GetAllPaginado")]
        public async Task<IActionResult> GetAllPaginado([FromQuery] FilterProvider listarParameter)
        {
            var result = await _providerQueries.GetAllPaginado(listarParameter);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetProveedorById")]
        public async Task<IActionResult> GetProviderById([FromQuery] ListarProviderByIdParameter id_parameter)
        {
            var resul = await _providerQueries.GetProviderById(id_parameter);
            return Ok(resul);
        }

        [HttpPost]//Crear
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] CreateProviderCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        } 
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateProviderCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllAutocomplete")]
        public async Task<IActionResult> GetAllAutocomplete([FromQuery] string query)
        {
            var result = await _providerQueries.GetAutocomplete(query);
            return Ok(result);
        }
        [HttpPost]
        [Route("GetProveedorByDetalleTipo")]
        public async Task<IActionResult> GetProveedorByDetalleTipo([FromBody] ProveedorDetalleTipoProductoFilter filter)
        {
            XElement productos = new XElement("DETALLETIPOPRODUCTOS", from c in filter.DetalleTipoProductos
                                                                select new
                                                                XElement("DETALLETIPOPRODUCTO",
                                                                        new XElement("idDetalleTipoProducto", c.idDetalleTipoProducto)));
            var result = await _providerQueries.GetProviderByDetalleTipoProducto(productos);
            return Ok(result);
        }
    }
}
