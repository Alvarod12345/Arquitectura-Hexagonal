using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OxiServi.Queries.Maestro
{
    public class EstadoOrdenViewModel
    {
        public int IdEstadoOrden { get; set; }
        public int Nombre { get; set; }
    }
    public class TipoMovimientoViewModel
    {
        public int IdTipoMovimiento { get; set; }
        public string Descripcion { get; set; }
    }
    public class RolViewModel
    {
        public int IdRol { get; set; }
        public string Descripcion { get; set; }
    }
    public class TipoDocuemntoViewModel
    {
        public int IdTipo { get; set; }
        public string Nombre { get; set; }
    }
    public class ImplementoViewModel
    {
        public int ImplementoId { get; set; }
        public string Descripcion { get; set; }
        public float Costo { get; set; }
        public bool isActive { get; set; }
    }
    public class DistritoViewModel
    {
        public int idDistrito { get; set; }
        public string nombre { get; set; }
        public float monto_adicional { get; set; }
    }
    public class DetalleTipoProductoViewModel
    {
        public int IdDetalleTipo { get; set; }
        public string Descripcion { get; set; }
        public int IdTipoProducto { get; set; }
    }
    public class ProveedorViewModel
    {
        public int IdProveedor { get; set; }
        public string Nombre { get; set; }
        public string tipo_producto { get; set; }
    }
    public class EstadoProductoViewModel
    {
        public int IdEstadoProducto { get; set; }
        public string Nombre { get; set; }
    }
    public class TipoComprobanteViewModel
    {
        public int IdTipoComprobante { get; set; }
        public string Descripcion { get; set; }
    }
}
