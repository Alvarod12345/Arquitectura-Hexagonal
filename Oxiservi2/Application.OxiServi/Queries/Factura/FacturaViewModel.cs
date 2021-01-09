using Application.OxiServi.Queries.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OxiServi.Queries.Factura
{
    public class FacturaViewModel
    {
        public int IdComprobante { get; set; }
        public int IdOrden { get; set; }
        public int IdEstadoComprobante { get; set; }
        public int IdTipoComprobante { get; set; }
    }
    public class FacturaPaginadoViewModel
    {
        public int IdComprobante { get; set; }
        public int IdEstadoComprobante { get; set; }
        public string nombre { get; set; }
        public string paterno { get; set; }
        public string materno { get; set; }
        public string razonSocial { get; set; }
        public int idOrden { get; set; }
        public float Costo { get; set; }
        public DateTime fechaEntrega { get; set; }
        public string fechaEntregaStr
        {
            get
            {
                return fechaEntrega.ToString("dd/MM/yyyy");
            }
        }
    }
    public class ListarFacturaViewModel : FilterBaseViewModel
    {

    }
    public class FacturaPaginado
    {
        public int Total { get; set; }
        public IEnumerable<FacturaPaginadoViewModel> factura { get; set; }
    }
}
