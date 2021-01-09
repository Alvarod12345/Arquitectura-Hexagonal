using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.OxiServi.Commands.TipoProducto
{
    [DataContract]
    public class CreateTipoProductoCommand:IRequest<int>
    {
        [DataMember]
        public string Nombre { get; set; }
    }
}
