using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.OxiServi.AggregatesModel.ProductoAggregate
{
    public class Producto
    {
        public int idProducto { get; set; }
        public string Serie { get; set; }
        public string Descripcion { get; set; }
        public float Capacidad { get; set; }
        public DateTime fechaFabricacion { get; set; }
        public DateTime fechaCaducidad { get; set; }
        public float Costo { get; set; }
        public int idDireccion { get; set; }
        public int idEstado { get; set; }
        public int idProveedor { get; set; }
        public int IdDetalleTipoDescripcion { get; set; }
        public int IdDetalleProducto { get; set; }

        public void Create(string serie , string Descripcion , float Capacidad , DateTime fechaFabricacion , DateTime fechaCaducidad,float Costo, 
                           int IdDetalleTipoDescripcion, int IdProveedor)
        {
            this.Serie = serie;
            this.Descripcion = Descripcion;
            this.Capacidad = Capacidad;
            this.fechaFabricacion = fechaFabricacion;
            this.fechaCaducidad = fechaCaducidad;
            this.Costo = Costo;
            this.IdDetalleTipoDescripcion = IdDetalleTipoDescripcion;
            this.idProveedor = IdProveedor;
        }
        public void Update(int idproducto ,string serie, int idProveedor, int IdDetalleTipo, string Descripcion,
            float Capacidad, DateTime fechaFabricacion, DateTime fechaCaducidad, float Costo)
        {
            this.idProducto = idproducto;
            this.Serie = serie;
            this.idProveedor = idProveedor;
            this.IdDetalleTipoDescripcion = IdDetalleTipo;
            this.Descripcion = Descripcion;
            this.Capacidad = Capacidad;
            this.fechaFabricacion =fechaFabricacion;
            this.fechaCaducidad = fechaCaducidad;
            this.Costo = Costo;
        }
        public void Desactivar(int idProducto)
        {
            this.idProducto = idProducto;
        }

       
    }
}
