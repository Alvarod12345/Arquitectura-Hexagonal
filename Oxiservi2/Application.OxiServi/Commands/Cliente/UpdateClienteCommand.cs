using MediatR;
using System.Runtime.Serialization;

namespace Application.OxiServi.Commands.Cliente
{
    [DataContract]
    public class UpdateClienteCommand : IRequest<int>
    {
        [DataMember]
        public int idCliente { get; set; }
        [DataMember]
        public string numDocumento { get; set; }
        [DataMember]
        public int tipoDocumento { get; set; }
        [DataMember]
        public DatosClienteUpdate datosCliente { get; set; }
        [DataMember]
        public DatosEmpresaUpdate datosEmpresa { get; set; }
    }
    public class DatosClienteUpdate
    {
        public string nombre { get; set; }
        public string paterno { get; set; }
        public string materno { get; set; }
        public string telefono { get; set; }
        public string correoElectronico { get; set; }
    }
    public class DatosEmpresaUpdate
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
