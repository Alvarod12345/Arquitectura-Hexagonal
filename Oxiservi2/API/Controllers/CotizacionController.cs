using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Application.OxiServi.Commands.Cotizacion;
using Application.OxiServi.Queries.Cotizacion;
using CrossCutting.Services.OxiServi.SmtpServices;
using CrossCutting.Utility.OxiServi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Cotizacion")]
    public class CotizacionController : Controller
    {
        public ICotizacionQueries _cotizacionQueries;
        public IMediator _mediator;
        public ISmtpServices _smtpServices;
        private readonly IHostingEnvironment _env;
        public CotizacionController(ICotizacionQueries cotizacionQueries, IMediator mediator, ISmtpServices smtpServices, IHostingEnvironment env)
        {
            _cotizacionQueries = cotizacionQueries;
            _mediator = mediator;
            _smtpServices = smtpServices;
            _env = env;
        }
        [HttpGet]
        [Route("GetAllPagination")]
        public async Task<IActionResult> GetAllPagination([FromQuery]CotizacionPaginationFilter filter)
        {
            var result = await _cotizacionQueries.GetAllCotizacionPaginado(filter);
            return Ok(result);
        }
        [HttpPost]
        [Route("CreateCotizacion")]
        public async Task<IActionResult> CreateCotizacion([FromBody]CreateCotizacionCommand command)
        {
            var result = await _mediator.Send(command);
            var cotizacion = await _cotizacionQueries.GetCotizacionById(result);
            var day = DateTime.Now.Day.ToString();
            var culture = new CultureInfo("ES-ES");
            var month = culture.DateTimeFormat.GetMonthName(DateTime.Now.Month);
            var year = DateTime.Now.Year.ToString();
            var model = new CotizacionOrden()
            {
                Dia = day,
                Mes = month,
                Anio = year,
                Direccion = cotizacion.Direccion,
                Correo = cotizacion.correoElectronico,
                CorreoEmpresa = cotizacion.correoElectronicoEmpresa,
                Nombre = cotizacion.NombreCliente,
                tipoDocumento = cotizacion.TipoDocumento,
                dni = cotizacion.numDocumento,
                SubTotal = cotizacion.Monto,
                PathPdf = System.IO.Path.GetFullPath(System.IO.Path.Combine(_env.ContentRootPath, "Report/Template/Cotizacion.html")),
                detalleCotizacion = (from cot in cotizacion.listProductos
                                     select new CotizacionDetalleOrden 
                                     { 
                                         Descripcion =cot.Descripcion,
                                         Precio = cot.Costo,
                                         Serie = cot.Serie,
                                         capacidad = cot.Capacidad
                                     }
                                     ).ToList()
            };
            var html = new TemplateExtension().CotizacionHtmlPdf(model);
            var correo = model.Correo == null ? model.CorreoEmpresa : model.Correo;
            var mail = new MailParameters()
            {
                ContentHtml = html,
                To = correo,
                FlagAttachemnt = false,
                Subject = "EMPRESA OXISERVI - COTIZACION"
            };
            await _smtpServices.SendMailSendGridAsync(mail);
            return Ok(result);
        }
        [HttpPost]
        [Route("GenerarOrden")]
        public async Task<IActionResult> GenerarOrden([FromBody]GenerarOrdenCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}