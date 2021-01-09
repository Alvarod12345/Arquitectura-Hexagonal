using MediatR;
using System;
using System.Runtime.Serialization;

namespace Application.OxiServi.Commands.Cliente
{
    [DataContract]
    public class CreateClienteCommand : IRequest<int>
    {
        [DataMember]
        public string numDocumento { get; set; }
        [DataMember]
        public int tipoDocumento { get; set; }
        [DataMember]
        public DatosCliente datosCliente { get; set; }
        [DataMember]
        public DatosEmpresa datosEmpresa { get; set; }
    }
    public class DatosCliente
    {
        public string nombre { get; set; }
        public string paterno { get; set; }
        public string materno { get; set; }
        public string telefono { get; set; }
        public string correoElectronico { get; set; }
    }
    public class DatosEmpresa
    {
        public string razonSocial { get; set; }
        public string nombreContacto { get; set; }
        public string paternoContacto { get; set; }
        public string maternoContacto { get; set; }
        public int tipoDocumentoContacto { get; set; }
        public string numDocumentoContacto { get; set; }
        public string telefonoContacto { get; set; }
        public string correoElectronicoContacto { get; set; }
    }
}
