using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Application.OxiServi.Commands.Orden;
using Application.OxiServi.Queries.Orden;
using CrossCutting.Services.OxiServi.SmtpServices;
using CrossCutting.Utility.OxiServi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static CrossCutting.Utility.OxiServi.Constants.ApplicationConstants;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Orden")]
    public class OrdenController : Controller
    {
        public IOrdenQueries _ordenQueries;
        public IMediator _mediator;
        public ISmtpServices _smtpServices;
        private readonly IHostingEnvironment _env;
        public OrdenController(IOrdenQueries ordenQueries, IMediator mediator, ISmtpServices smtpServices, IHostingEnvironment env)
        {
            _ordenQueries = ordenQueries;
            _mediator = mediator;
            _smtpServices = smtpServices;
            _env = env;
        }
        [HttpGet]
        [Route("GetAllPaginationWeb")]
        public async Task<IActionResult> GetAllPaginationWeb([FromQuery]FilterOrdenWebViewModel filter)
        {
            var result = await _ordenQueries.GetAllPaginationWeb(filter);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllPagination")]
        public async Task<IActionResult> GetAllPagination([FromQuery]FilterOrdenViewModel filter)
        {
            var result = await _ordenQueries.GetAllPagination(filter);
            return Ok(result);
        }
        [HttpPut]
        [Route("UpdateEstado")]
        public async Task<IActionResult> UpdateEstado([FromBody]UpdateEstadoOrdenCommand command)
        {
            var result = await _mediator.Send(command);
            if (command.EstadoOrdenId == 7){
                var orden = await _ordenQueries.GetFacturaByOrden(command.OrdenId);
               
                var day = DateTime.Now.Day.ToString();
                var culture = new CultureInfo("ES-ES");
                var month = culture.DateTimeFormat.GetMonthName(DateTime.Now.Month);
                var year = DateTime.Now.Year.ToString().Split("02")[0] + DateTime.Now.Year.ToString().Split("02")[1];
                var model = new FacturaOrden()
                {
                    Direccion = orden.Direccion,
                    DNI = orden.numDocumento,
                    TipoDocumento = orden.tipoDocumento,
                    FullName = orden.FullName,
                    SubTotal = orden.SubTotal,
                    Total = orden.SubTotal,
                    Anio = year,
                    Dia = day,
                    Mes = month,
                    detalleOrden = ( from @do in orden.detalleOrden
                                     select new FacturaDetalleOrdenModel
                                     {
                                         Descripcion = @do.Descripcion,
                                         PUnitario = @do.PUnitario,
                                         Serie = @do.Serie
                                     }
                                    ).ToList()
                };
                if (orden.IdTipoComprobante == (int)TipoComprobante.FACTURA)
                {
                    model.PathPdf = System.IO.Path.GetFullPath(System.IO.Path.Combine(_env.ContentRootPath, "Report/Template/Factura.html"));
                    var html = new TemplateExtension().FacturaHtmlPdf(model);
                    var mail = new MailParameters()
                    {
                        ContentHtml = html,
                        To = orden.correoElectronico,
                        FlagAttachemnt = false,
                        Subject = "EMPRESA OXISERVI - BOLETA"
                    };
                    await _smtpServices.SendMailSendGridAsync(mail);
                }
                else if(orden.IdTipoComprobante == (int)TipoComprobante.BOLETA)
                {
                    model.PathPdf = System.IO.Path.GetFullPath(System.IO.Path.Combine(_env.ContentRootPath, "Report/Template/Boleta.html"));
                    var html = new TemplateExtension().BoletaHtmlPdf(model);
                    var mail = new MailParameters()
                    {
                        ContentHtml = html,
                        To = orden.correoElectronico,
                        FlagAttachemnt = false,
                        Subject = "EMPRESA OXISERVI - BOLETA"
                    };
                    await _smtpServices.SendMailSendGridAsync(mail);
                }
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("GetEstadoOrdenUpdate")]
        public async Task<IActionResult> GetEstadoOrdenUpdate([FromQuery]int idEstadoOrden)
        {
            var result = await _ordenQueries.GetEstadoDispoible(idEstadoOrden);
            return Ok(result);
        }
        [HttpPost]
        [Route("CancelarOrden")]
        public async Task<IActionResult> CancelarOrden([FromBody]CancelarOrdenCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}