using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.OxiServi.Commands.Provider
{
    [DataContract]
    public class CreateProviderCommand : IRequest<int>
    {
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string numDocumento { get; set; }
        [DataMember]
        public int tipoDocumento { get; set; }
        [DataMember]
        public string telefono { get; set; }
        [DataMember]
        public string referente { get; set; }
        [DataMember]
        public List<DetalleTipoProducto> listaDetalleTipoProducto{ get; set; }
    }
    [DataContract]
    public class DetalleTipoProducto
    {
        [DataMember]
        public int idDetalleTipo { get; set; }
        [DataMember]
        public Boolean isREcarga { get; set; }
        [DataMember]
        public Boolean isVendedor { get; set; }
        //recargable
    }
}
