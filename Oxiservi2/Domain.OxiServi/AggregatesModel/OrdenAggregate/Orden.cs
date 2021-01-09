using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.OxiServi.AggregatesModel.OrdenAggregate
{
    public class Orden
    {
        public int idOrden { get; set; }
        public int idCliente { get; set; }
        public int idEstadoOrden { get; set; }
        public void UpdateEstado(int idOrden,int idEstadoOrden)
        {
            this.idOrden = idOrden;
            this.idEstadoOrden = idEstadoOrden;
        }
    }
}
