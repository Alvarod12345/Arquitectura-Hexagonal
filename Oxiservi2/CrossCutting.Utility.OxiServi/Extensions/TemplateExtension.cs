using CrossCutting.Utility.OxiServi.Constants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace CrossCutting.Utility.OxiServi.Extensions
{
    public class TemplateExtension
    {
        public string BoletaHtmlPdf(FacturaOrden factura)
        {
            //string generalTemplate = ReadPhysicalFile(factura.PathPdf);
            string generalTemplate = "";
            using (WebClient client = new WebClient())
            {
                generalTemplate = client.DownloadString("https://firebasestorage.googleapis.com/v0/b/proyectovents.appspot.com/o/Boleta.html?alt=media&token=74db8166-a42a-4f02-9f49-2bbf4a70f626.html");
            }
            string bodyMessage = TemplateFacturPdf(generalTemplate, factura);

            return bodyMessage;
        }
        public string FacturaHtmlPdf(FacturaOrden factura)
        {
            //string generalTemplate = ReadPhysicalFile(factura.PathPdf);
            string generalTemplate = "";
            using (WebClient client = new WebClient())
            {
                generalTemplate = client.DownloadString("https://firebasestorage.googleapis.com/v0/b/proyectovents.appspot.com/o/Factura.html?alt=media&token=1eccb03e-d258-4967-9f09-bfa33778a5e2.html");
            }
            string bodyMessage = TemplateFacturPdf(generalTemplate, factura);

            return bodyMessage;
        }
        public string TemplateBoletaPdf(string generalTemplate, FacturaOrden factura)
        {
            string productosTable = string.Empty;
            foreach (var item in factura.detalleOrden)
            {
                productosTable += TemplateConstans.facturaTemplate
                .Replace("{Serie}", item.Serie)
                .Replace("{Descripcion}", item.Descripcion)
                .Replace("{PUnitario}", "S/ " + item.PUnitario.ToString());
            }

            string emailMessage = generalTemplate
            .Replace("{TipoDocumento}", factura.TipoDocumento)
            .Replace("{D.N.I}", factura.DNI)
            .Replace("{anio}", factura.Anio.ToString())
            .Replace("{dia}", factura.Dia)
            .Replace("{mes}", factura.Mes)
            .Replace("{Direccion}", factura.Direccion)
            .Replace("{FullName}", factura.FullName)
            .Replace("{ProductosTable}", productosTable)
            .Replace("{subTotal}", "S/ " + factura.SubTotal)
            .Replace("{total}", "S/ " + factura.Total);
            return emailMessage;
        }
        public string TemplateFacturPdf(string generalTemplate, FacturaOrden factura)
        {
            string productosTable = string.Empty;
            foreach (var item in factura.detalleOrden)
            {
                productosTable += TemplateConstans.facturaTemplate
                .Replace("{Serie}", item.Serie)
                .Replace("{Descripcion}", item.Descripcion)
                .Replace("{PUnitario}", "S/ " + item.PUnitario.ToString());
            }

            string emailMessage = generalTemplate
            .Replace("{TipoDocumento}", factura.TipoDocumento)
            .Replace("{D.N.I}", factura.DNI)
            .Replace("{anio}", factura.Anio.ToString())
            .Replace("{dia}", factura.Dia)
            .Replace("{mes}", factura.Mes)
            .Replace("{Direccion}", factura.Direccion)
            .Replace("{FullName}", factura.FullName)
            .Replace("{ProductosTable}", productosTable)
            .Replace("{subTotal}", "S/ " + factura.SubTotal)
            .Replace("{total}", "S/ " + factura.Total);
            return emailMessage;
        }
        private string ReadPhysicalFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"La plantilla del archivo localizado en \"{path}\" no fué encontrada.");
            }

            using (var fs = System.IO.File.OpenRead(path))
            {
                using (var sr = new StreamReader(fs))
                {
                    return sr.ReadToEnd();
                }
            }
        }


        public string CotizacionHtmlPdf(CotizacionOrden cotizacion)
        {
            //string generalTemplate = ReadPhysicalFile(cotizacion.PathPdf);
            string generalTemplate = "";
            using (WebClient client = new WebClient())
            {
                generalTemplate = client.DownloadString("https://firebasestorage.googleapis.com/v0/b/proyectovents.appspot.com/o/Cotizacion.html?alt=media&token=8c2158e7-0762-4ea4-be47-41f6e4f43d2b.html");
            }
            string bodyMessage = TemplateCotizacionPdf(generalTemplate, cotizacion);

            return bodyMessage;
        }
        public string TemplateCotizacionPdf(string generalTemplate, CotizacionOrden cotizacion)
        {
            string productosTable = string.Empty;
            foreach (var item in cotizacion.detalleCotizacion)
            {
                productosTable += TemplateConstans.cotizacionTemplate
                .Replace("{Serie}", item.Serie)
                .Replace("{Descripcion}", item.Descripcion)
                .Replace("{Capacidad}", item.capacidad.ToString())
                .Replace("{PUnitario}", "S/ " + item.Precio.ToString());
            }

            string emailMessage = generalTemplate
            .Replace("{anio}", cotizacion.Anio.ToString())
            .Replace("{dia}", cotizacion.Dia)
            .Replace("{mes}", cotizacion.Mes)
            .Replace("{Direccion}", cotizacion.Direccion)
            .Replace("{FullName}", cotizacion.Nombre)
            .Replace("{ProductosTable}", productosTable)
            .Replace("{D.N.I}",cotizacion.dni)
            .Replace("{TipoDocumento}",cotizacion.tipoDocumento)
            .Replace("{subTotal}", "S/ " + cotizacion.SubTotal)
            .Replace("{total}", "S/ " + cotizacion.SubTotal);
            return emailMessage;
        }
    }
    public class FacturaOrden
    {
        public string PathPdf { get; set; }
        public string FullName { get; set; }
        public string Direccion { get; set; }
        public int IdTipoProducto { get; set; }
        public string TipoProducto { get; set; }
        public string Dia { get; set; }
        public string Mes { get; set; }
        public string Anio { get; set; }
        public string TipoDocumento { get; set; }
        public string DNI { get; set; }
        public string UrlFirma { get; set; }
        public double SubTotal { get; set; }
        public double Total { get; set; }
        public List<FacturaDetalleOrdenModel> detalleOrden { get; set; }

    }
    public class FacturaDetalleOrdenModel
    {
        public string Descripcion { get; set; }
        public double PUnitario { get; set; }
        public string Serie { get; set; }
    }
    public class FacturaDetalleOrden
    {
        public int Cantidad { get; set; }
        public int Unidad { get; set; }
        public string Descripcion { get; set; }
        public double PUnitario { get; set; }
    }

    public class CotizacionOrden
    {
        public string PathPdf { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string CorreoEmpresa { get; set; }
        public string Dia { get; set; }
        public string Mes { get; set; }
        public string Anio { get; set; }
        public string tipoDocumento { get; set; }
        public string dni { get; set; }
        public string UrlFirma { get; set; }
        public double SubTotal { get; set; }
        public double Total { get; set; }
        public List<CotizacionDetalleOrden> detalleCotizacion { get; set; }
    }
    public class CotizacionDetalleOrden
    {
        public string Serie { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public float capacidad { get; set; }
    }
}
