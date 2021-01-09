using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Domain.OxiServi.AggregatesModel.CotizacionAggregate
{
    public class Cotizacion
    {
        public int CotizacionId { get; set; }
        public int idCliente { get; set; }
        public float Monto { get; set; }
        public int idDireccion { get; set; }
        public int CotizacionProductoId { get; set; }
        public int ProductoId { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int IdTipoComprobante { get; set; }
        public XmlElement XMLCotizacion { get; set; }
        public string NumeroOrden { get; set; }
        public string RUC { get; set; }
        public void Create(int idCliente, float monto, int idDireccion)
        {
            this.idCliente = idCliente;
            this.Monto = monto;
            this.idDireccion = idDireccion;
            
        }
        public void GenerarOrden(int cotizacionId, DateTime fechaEntrega,int idTipoComprobante, string numeroOrden,string ruc)
        {
            CotizacionId = cotizacionId;
            FechaEntrega = fechaEntrega;
            IdTipoComprobante = idTipoComprobante;
            NumeroOrden = numeroOrden;
            RUC = ruc;
        }
    }
}
