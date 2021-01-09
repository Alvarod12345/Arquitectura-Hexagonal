using Application.OxiServi.Queries.Base;
using Application.OxiServi.Queries.Cliente;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OxiServi.Queries.Orden
{
    public class OrdenViewModel
    {
        public int idOrden { get; set; }
        public int idCliente { get; set; }
        public string NombreCliente { get; set; }
        public string direccion { get; set; }
        public int idEstadoOrden { get; set; }
        public string EstadoOrden { get; set; }
        public DateTime fechaEntrega { get; set; }
        public string fechaEntregaStr
        {
            get
            {
                return fechaEntrega.ToString("dd/MM/yyyy");
            }
        }

    }
    public class OrdenWebViewModelBase
    {
        public int idOrden { get; set; }
        public int idEstadoOrden { get; set; }
        public string estadoOrden { get; set; }
        public DateTime fechaEntrega { get; set; }
        public string fechaEntregaStr
        {
            get
            {
                return fechaEntrega.ToString("dd/MM/yyyy");
            }
        }
        public double monto { get; set; }
        public int idCliente { get; set; }
        public string numDocumento { get; set; }
        public int tipoDocumento { get; set; }
        public string tipoDocumentoStr { get; set; }
        public int idDatosCliente { get; set; }
        public int idDatosEmpresa { get; set; }
        public string nombre { get; set; }
        public string materno { get; set; }
        public string paterno { get; set; }
        public string telefono { get; set; }
        public string correoElectronico { get; set; }
        public string razonSocial { get; set; }
        public string nombreContacto { get; set; }
        public string paternoContacto { get; set; }
        public string maternoContacto { get; set; }
        public string numDocumentoContacto { get; set; }
        public string tipoDocumentoContacto { get; set; }
        public string tipoDocumentoContactoStr { get; set; }
        public string telefonoContacto { get; set; }
        public string correoElectronicoContacto { get; set; }
    }
    public class OrdenWebPaginationViewModel
    {
        public int Total { get; set; }
        public List<OrdenWebViewModel> orden { get; set; }
    }
    public class OrdenWebViewModel
    {
        public ClientePaginationModel cliente { get; set; }
        public OrdenViewModel orden { get; set; }
    }
    public class FilterOrdenViewModel : FilterBaseViewModel
    {
        public string fechaEntrega { get; set; }
    }
    public class FilterOrdenWebViewModel : FilterBaseViewModel
    {
        public string fechaEntrega { get; set; }
        public int idEstadoOrden { get; set; }
        public int idTipoDocumento { get; set; }
        public string numDocumento { get; set; }
        public string NombreCliente { get; set; }
        public string RazonSocial { get; set; }
    }
    public class EstadoOrdenViewModel
    {
        public int idEstadoOrden { get; set; }
        public string nombre { get; set; }
    }
    public class FacturaOrdenBaseModel
    {
        public int idOrden { get; set; }
        public string correoElectronico { get; set; }
        public string correoElectronicoEmpresa { get; set; }
        public string numDocumento { get; set; }
        public int TipoDocumentoId { get; set; }
        public string TipoDocumento { get; set; }
        public string ClienteName { get; set; }
        public string RazonSocial { get; set; }
        public string DetalleTipo { get; set; }
        public string Direccion { get; set; }
        public int IdTipoComprobante { get; set; }
        public string TipoComprobante { get; set; }
        public string Descripcion { get; set; }
        public double PUnitario { get; set; }
        public string Serie { get; set; }
    }
    public class FacturaOrdenViewModel
    {
        public int idOrden { get; set; }
        public int IdTipoComprobante { get; set; }
        public string TipoComprobante { get; set; }
        public string correoElectronico { get; set; }
        public string FullName { get; set; }
        public string numDocumento { get; set; }
        public string tipoDocumento { get; set; }
        public string Direccion { get; set; }
        public double Total { get; set; }
        public double SubTotal { get; set; }
        public List<FacturaDetalleOrdenViewModel> detalleOrden { get; set; }
    }
    public class FacturaDetalleOrdenViewModel
    {
        public string DetalleTipoProducto { get; set; }
        public string Descripcion { get; set; }
        public double PUnitario { get; set; }
        public string Serie { get; set; }
    }
}
