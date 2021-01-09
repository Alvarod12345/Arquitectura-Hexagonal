using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.OxiServi.Commands.Orden
{
    [DataContract]
    public class CancelarOrdenCommand : IRequest<int>
    {
        [DataMember]
        public int idOrden { get; set; }
    }
}