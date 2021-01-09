using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.OxiServi.Commands.DetalleTipoProducto
{
    [DataContract]
    public class DesactivarDetalleTipoProductoCommand : IRequest<int>
    {
        [DataMember]
        public int idTipoProducto { get; set; }
    }
}
