using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.OxiServi.AggregatesModel.FacturaAggregate
{
    public class Factura
    {
        public int IdComprobante { get; set; }
        public int IdOrden { get; set; }
        public int IdEstadoComprobante { get; set; }
        public void UpdateEstado(int IdComprobante)
        {
            this.IdComprobante = IdComprobante;
        }
    }
}
