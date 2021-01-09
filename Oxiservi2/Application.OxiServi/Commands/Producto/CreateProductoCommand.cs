using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.OxiServi.Commands.Producto
{
    [DataContract]
    public class CreateProductoCommand : IRequest<int>
    {
        [DataMember]
        public string Serie { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public float Capacidad { get; set; }
        [DataMember]
        public string fechaFabricacion { get; set; }
        [DataMember]
        public string fechaCaducidad { get; set; }
        [DataMember]
        public float Costo { get; set; }
        [DataMember]
        public int idProveedor{ get; set; }
        [DataMember]
        public int IdDetalleTipoProducto { get; set; }
    }
}
