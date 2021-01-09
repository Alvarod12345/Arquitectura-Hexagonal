using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.OxiServi.Queries.Maestro;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Maestro")]
    public class MaestroController : Controller
    {
        public IMaestroQueries _maestroQueries;
        public MaestroController(IMaestroQueries maestroQueries)
        {
            _maestroQueries = maestroQueries;
        }
        [HttpGet]
        [Route("GetAllEstadoOrden")]
        public async Task<IActionResult> GetAllEstadoOrden()
        {
            var result = await _maestroQueries.GetAllEstadoOrden();
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllTipoMovimiento")]
        public async Task<IActionResult> GetAllTipoMovimiento()
        {
            var result = await _maestroQueries.GetAllTipoMovimiento();
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllRol")]
        public async Task<IActionResult> GetAllRol()
        {
            var result = await _maestroQueries.GetAllRol();
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllTipoDocumento")]
        public async Task<IActionResult> GetAllTipoDocumento()
        {
            var result = await _maestroQueries.GetAllTipoDocumento();
            return Ok(result);
        }
        [HttpGet]
        [Route("GetImplemento")]
        public async Task<IActionResult> GetImplemento()
        {
            var result = await _maestroQueries.GetImplemento();
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllDistrito")]
        public async Task<IActionResult> GetAllDistrito()
        {
            var result = await _maestroQueries.GetAllDistrito();
            return Ok(result);
        }
        [HttpGet]
        [Route("GetDetalleTipoProductoByTipoProducto")]
        public async Task<IActionResult> GetDetalleTipoProductoByTipoProducto([FromQuery] int idTipoProducto)
        {
            var result = await _maestroQueries.GetAllDetalleTipoProducto(idTipoProducto);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetProveedorByTipoProducto")]
        public async Task<IActionResult> GetProveedorByTipoProducto([FromQuery] int idTipoProducto)
        {
            var result = await _maestroQueries.GetProveedorByTipoProducto(idTipoProducto);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllEstadoProducto")]
        public async Task<IActionResult> GetAllEstadoProducto()
        {
            var result = await _maestroQueries.GetAllEstadosProducto();
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllTipoComprobante")]
        public async Task<IActionResult> GetAllTipoComprobante()
        {
            var result = await _maestroQueries.GetAllTipoComprobante();
            return Ok(result);
        }
    }
}
