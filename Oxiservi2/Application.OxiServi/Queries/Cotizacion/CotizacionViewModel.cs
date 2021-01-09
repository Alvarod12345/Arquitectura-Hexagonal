using Application.OxiServi.Queries.Base;
using Application.OxiServi.Queries.Producto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OxiServi.Queries.Cotizacion
{
    public class CotizacionViewModel
    {
        public int IdCotizacion { get; set; }
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string correoElectronicoEmpresa { get; set; }
        public string correoElectronico { get; set; }
        public string RazonSocial { get; set; }
        public string TipoDocumento { get; set; }
        public string numDocumento { get; set; }
        public double Monto { get; set; }
        public int idDireccion { get; set; }
        public string Direccion { get; set; }
        public string serie { get; set; }
        public string descripcionProd { get; set; }
        public float Capacidad { get; set; }
        public float precioProd { get; set; }
        public string descripcionImp { get; set; }
        public string Email { get; set; }
        public float precioImp { get; set; }
    }

    public class CotizacionPaginado : ProductoViewModel
    {
        public int IdCotizacion { get; set; }
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string RazonSocial { get; set; }
        public string TipoDocumento { get; set; }
        public string numDocumento { get; set; }
        public double Monto { get; set; }
        public int idDireccion { get; set; }
        public string Direccion { get; set; }
        public string descripcionImp { get; set; }
        public float precioImp { get; set; }
        public int ImplementoId { get; set; }
    }

    public class Cotizacion
    {
        public int IdCotizacion { get; set; }
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string RazonSocial { get; set; }
        public string correoElectronico { get; set; }
        public string correoElectronicoEmpresa { get; set; }
        public string TipoDocumento { get; set; }
        public string numDocumento { get; set; }
        public double Monto { get; set; }
        public int idDireccion { get; set; }
        public string Direccion { get; set; }
        public List<ProductoCotizacion> listProductos { get; set; }
    }

    public class ProductoCotizacion : ProductoViewModel
    {
        public ImplementoCotizacion implemento { get; set; }
    }

    public class ImplementoCotizacion
    {
        public int implementoId { get; set; }
        public string descripcion { get; set; }
        public float costo { get; set; }
    }

    public class CotizacionDetalleViewModel
    {
        public string Serie { get; set; }
        public string Descripcion { get; set; }
        public string Precio { get; set; }
    }
    public class PaginaCotizacionPaginado
    {
        public int Total { get; set; }
        public IEnumerable<Cotizacion> cotizaciones { get; set; }
    }
    public class CotizacioProductoViewModel : CotizacionViewModel
    {
        List<CotizacionDetalleViewModel> productos { get; set; }
    }
    public class CotizacionPaginationFilter : FilterBaseViewModel
    {
        public int estado { get; set; }
    }
}
