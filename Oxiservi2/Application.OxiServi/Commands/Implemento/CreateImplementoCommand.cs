using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.OxiServi.Commands.Implemento
{
    [DataContract]
    public class CreateImplementoCommand : IRequest<int>
    {
        [DataMember]
        public string Descripcion { get; set; } 
        [DataMember]
        public float Precio { get; set; }
    }
}
