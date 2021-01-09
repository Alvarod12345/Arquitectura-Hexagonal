using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.OxiServi.AggregatesModel.DetalleTipoProductoAggregate
{
    public class DetalleTipoProducto
    {
        public string descripcion { get; set; }
        public int idTipoProducto { get; set; }
        public int result { get; set; }

        public void CreateDetalleProducto(string descripcion, int idTipoProducto)
        {
            this.descripcion = descripcion;
            this.idTipoProducto = idTipoProducto;
        }

        public void DesactivarDetalleTipoProducto(int idTipoProducto)
        {
            this.idTipoProducto = idTipoProducto;
        }

        public void DeleteDetalleTipoProducto(int idTipoProducto)
        {
            this.idTipoProducto = idTipoProducto;
        }
    }
}
