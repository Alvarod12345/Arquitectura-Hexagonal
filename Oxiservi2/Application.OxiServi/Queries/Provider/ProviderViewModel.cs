using Application.OxiServi.Queries.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OxiServi.Queries.Provider
{
    public class ProviderViewModel
    {
        public int idProveedor { get; set; }
        public string nombre { get; set; }
        public string numDocumento { get; set; }
        public int tipoDocumento { get; set; }
        public string telefono { get; set; }
        public string referente { get; set; }
        public int idTipoProducto { get; set; }
        public string Nombre_TipoProducto { get; set; }
        public int idDetalleTipo { get; set; }
        public string descripcion { get; set; }
        public bool isRecarga { get; set; }
        public bool isVendedor { get; set; }
    }
    public class ProviderViewModelPaginado
    {
        public List<ListarProviderViewModel> lista { get; set; }
        public int total { get; set; }
    }
    public class ListarProviderViewModel
    {
        public int idProveedor { get; set; }
        public string nombre { get; set; }
        public string numDocumento { get; set; }
        public int tipoDocumento { get; set; }
        public string telefono { get; set; }
        public string referente { get; set; }
        public List<TipoProducto> tipoProducto { get; set; }
        
    }
    public class TipoProducto
    {
        public int idTipoProducto { get; set; }
        public string Nombre_TipoProducto { get; set; }
        public List<TipoDetalle> tipoDetalle { get; set; }        
    }
    public class TipoDetalle
    {
        public int idDetalleTipo { get; set; }
        public string descripcion { get; set; }
        public bool isRecarga { get; set; }
        public bool isVendedor { get; set; }
    }
    public class ListarProviderByNamesParameter
    {
        public string nombre { get; set; }
    }
    public class FilterProvider : FilterBaseViewModel
    {
        public int idProveedor { get; set; }
        public string nombre { get; set; }
        public string numDocumento { get; set; }
    }
    public class ListarFiltroProviderViewModel : FilterBaseViewModel
    {
        public string Nombre { get; set; }
    }
    public class ListarProviderByIdParameter
    {
        public int idProveedor { get; set; }
    }

    public class ProveedorDetalleTipoProductoFilter
    {
        public List<ProveedorIdDetalleTipoProducto> DetalleTipoProductos { get; set; }
    }

    public class ProveedorIdDetalleTipoProducto
    {
        public int idDetalleTipoProducto { get; set; }
    }
}
