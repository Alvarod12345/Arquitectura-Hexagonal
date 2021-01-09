using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.OxiServi.AggregatesModel.TipoProductoAggregate
{
    public class TipoProducto
    {
        public int idTipoProducto { get; set; }
        public string Nombre { get; set; }
        public int result { get; set; }

        public void CreateTipoProducto(string nombre)
        {
            this.Nombre = nombre;
        }
        public void DesactivateTipoProducto(int idTipoProducto)
        {
            this.idTipoProducto = idTipoProducto;
        }
        public void DeleteTipoProducto(int idTipoProducto)
        {
            this.idTipoProducto = idTipoProducto;
        }
    }
    
}
