using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Infrastructure.Extensions;
using Application.OxiServi.Commands.Cliente;
using Application.OxiServi.Queries.Cliente;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Cliente")]
    public class ClienteController : Controller
    {
        public IClienteQueries clienteQueries;
        public IMediator mediator;
        public ClienteController(IClienteQueries iclienteQueries, IMediator mediator)
        {
            this.clienteQueries = iclienteQueries;
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] CreateClienteCommand cliente)
        {
            JsonResponse jsonResponse = new JsonResponse();
            var result = await mediator.Send(cliente);
            jsonResponse.Id = result;
            if (result > default(int))
            {
                jsonResponse.Message = "Registrado!";
                jsonResponse.Result = true;
            }
            else
            {
                if (result == -1)
                    jsonResponse.Message = "Debe ingresar datos de cliente o empresa.";
                if (result == -2)
                    jsonResponse.Message = "Si seleccionó RUC no debe llenar los datos de persona.";
                jsonResponse.Result = false;
                if (result == -3)
                    jsonResponse.Message = "Si seleccionó RUC no debe llenar los datos de persona.";
                jsonResponse.Result = false;
            }
            return Ok(result);
        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateClienteCommand cliente)
        {
            JsonResponse jsonResponse = new JsonResponse();
            var result = await mediator.Send(cliente);
            jsonResponse.Id = result;
            //if (result > default(int))
            //{
            //    jsonResponse.Message = "Registrado!";
            //    jsonResponse.Result = true;
            //}
            //else
            //{
            //    if (result == -1)
            //        jsonResponse.Message = "Debe ingresar datos de cliente o empresa.";
            //    if (result == -2)
            //        jsonResponse.Message = "Si seleccionó RUC no debe llenar los datos de persona.";
            //    jsonResponse.Result = false;
            //}
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllPagination")]
        public async Task<IActionResult> GetAllPagination([FromQuery] FilterClienteViewModel filter)
        {
            if (filter.TipoDocumento == 3)
                filter.NombreCliente = null;
            if (filter.TipoDocumento != 3)
                filter.RazonSocial = null;
            var result = await clienteQueries.GetAllPagination(filter);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetClienteCotizacion")]
        public async Task<IActionResult> GetClienteCotizacion([FromQuery]FilterClienteCotizacionViewModel filter)
        {
            if (filter.TipoDocumento == 3)
                filter.NombreCliente = null;
            if (filter.TipoDocumento != 3)
                filter.RazonSocial = null;
            var result = await clienteQueries.GetClienteCotizacion(filter);
            return Ok(result);
        }
    }
}