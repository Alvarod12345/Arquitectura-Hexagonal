using Application.OxiServi.Queries.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OxiServi.Queries.Producto
{
    public class ProductoViewModel
    {
        public int idProducto { get; set; }
        public string Serie { get; set; }
        public string Proveedor { get; set; }
        public int idProveedor { get; set; }
        public string detalleTipo { get; set; }
        public int idDetalleTipo { get; set; }
        public string TipoProducto { get; set; }
        public int idTipoProducto { get; set; }
        public string Descripcion { get; set; }
        public float Capacidad { get; set; }
        public bool isActive { get; set; }
        public DateTime fechaFabricacion { get; set; }
        public string FechaFabricacionStr
        {
            get
            {
                return fechaFabricacion.ToString("dd/MM/yyyy");
            }
        }
        public DateTime fechaCaducidad { get; set; }
        public string FechaCaducidadStr
        {
            get
            {
                return fechaCaducidad.ToString("dd/MM/yyyy");
            }
        }
        public float Costo { get; set; }
        public string EstadoProducto { get; set; }
        public int idEstadoProducto { get; set; }
    }
    public class ListarProductoModel
    {
        public int idProducto { get; set; }
        public string Serie { get; set; }
        public string Descripcion { get; set; }
        public string Tipo_producto { get; set; }
        public double Capacidad { get; set; }
        public string Ubicacion { get; set; }
        public bool isActive { get; set; }
        public string Estadoproducto { get; set; }
    }
    public class ListarProductoViewModel
    {
        public IEnumerable<ProductoViewModel> rows { get; set; }
        public int Total { get; set; }
    }
    public class ListarProductoByIdParametro
    {
        public int idProducto { get; set; }
    }
    public class ListarFiltroProductoViewModel : FilterBaseViewModel
    {
        public int EstadoProducto { get; set; }
        public int idTipoProducto { get; set; }
        public int idDetalleTipoProducto { get; set; }
        public string Serie { get; set; }
    }

    public class ListarTipoProductoViewModel
    {
        public int idTipoProducto { get; set; }
        public string Nombre { get; set; }
    }
    public class ListarImplementoViewModel
    {
        public int ImplementoId { get; set; }
        public string Descripcion { get; set; }
        public float Costo { get; set; }
    }
    public class ListarProductoRecarga
    {
        public int idProducto { get; set; }
        public string serie { get; set; }
        public string estado { get; set; }
        public string tipoProducto { get; set; }
    }
    public class ProductoRecargaBaseModel
    {
        public string Serie { get; set; }
        public int idRecarga { get; set; }
        public int idProducto { get; set; }
        public string Producto { get; set; }
        public int DetalleTipoProductoId { get; set; }
        public string DetalleTipoProducto { get; set; }
        public int TipoProductoId { get; set; }
        public string TipoProducto { get; set; }
        public int EstadoProductoId { get; set; }
        public string EstadoProducto { get; set; }
    }
    public class ProductoRecargaViewModel
    {
        public string Serie { get; set; }
        public int idProducto { get; set; }
        public string Producto { get; set; }
        public int DetalleTipoProductoId { get; set; }
        public string DetalleTipoProducto { get; set; }
        public int TipoProductoId { get; set; }
        public string TipoProducto { get; set; }
        public int EstadoProductoId { get; set; }
        public string Estado { get; set; }
    }
}
