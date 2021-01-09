using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.OxiServi.Commands.Provider
{
    [DataContract]
    public class UpdateProviderCommand : IRequest<int>
    {
        [DataMember]
        public int IdProveedor { get; set; } 
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public string Referente { get; set; }
        [DataMember]
        public string NumDocumento { get; set; }
        [DataMember]
        public List<DetalleTipoProductos> listaDetalleTipoProductos { get; set; }
    }
    public class DetalleTipoProductos
    {
        [DataMember]
        public int idDetalleTipo { get; set; }
        [DataMember]
        public Boolean isREcarga { get; set; }
        [DataMember]
        public Boolean isVendedor { get; set; }
    }
}
