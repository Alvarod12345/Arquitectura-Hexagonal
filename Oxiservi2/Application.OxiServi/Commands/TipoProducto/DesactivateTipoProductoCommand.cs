using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.OxiServi.Commands.TipoProducto
{
    [DataContract]
    public class DesactivateTipoProductoCommand:IRequest<int>
    {
        [DataMember]
        public int idTipoProducto { get; set; }
    }
}
