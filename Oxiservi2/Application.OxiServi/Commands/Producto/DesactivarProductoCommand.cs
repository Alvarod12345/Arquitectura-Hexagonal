using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.OxiServi.Commands.Producto
{
    [DataContract]
    public class DesactivarProductoCommand : IRequest<bool>
    {
        [DataMember]
        public int idProducto { get; set; }
    }
}
