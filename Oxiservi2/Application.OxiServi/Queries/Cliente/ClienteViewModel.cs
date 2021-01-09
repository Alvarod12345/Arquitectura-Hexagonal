using Application.OxiServi.Queries.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OxiServi.Queries.Cliente
{
    public class ClienteViewModel
    {
        public int idCliente { get; set; }
        public int idDatoscliente { get; set; }
        public int idDatosEmpresa { get; set; }
        public int id_tipo_cliente { get; set; }
    }
    public class ClienteBasePaginationViewModel
    {
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
        public string RUC { get; set; }
    }
    public class FilterClienteViewModel : FilterBaseViewModel
    {
        public string NombreCliente { get; set; }
        public string RazonSocial { get; set; }
        public string NumeroDocumento { get; set; }
        public int TipoDocumento { get; set; }
    }
    public class FilterClienteCotizacionViewModel
    {
        public string NombreCliente { get; set; }
        public string RazonSocial { get; set; }
        public string NumeroDocumento { get; set; }
        public int TipoDocumento { get; set; }
    }
    public class ClientePaginationViewModel
    {
        public int Total { get; set; }
        public List<ClientePaginationModel> rows { get; set; }
    }
    public class ClientePaginationModel
    {
        public int idCliente { get; set; }
        public string numDocumento { get; set; }
        public int tipoDocumento { get; set; }
        public string tipoDocumentoStr { get; set; }
        public ClientePersonaModel persona { get; set; }
        public ClienteEmpresaModel empresa { get; set; }

    }
    public class ClientePersonaModel
    {
        public int idDatosCliente { get; set; }
        public string nombre { get; set; }
        public string materno { get; set; }
        public string paterno { get; set; }
        public string telefono { get; set; }
        public string correoElectronico { get; set; }
        public string RUC { get; set; }
    }
    public class ClienteEmpresaModel
    {
        public int idDatosEmpresa { get; set; }
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
}
