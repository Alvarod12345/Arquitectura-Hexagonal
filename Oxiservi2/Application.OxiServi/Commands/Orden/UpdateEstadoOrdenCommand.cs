using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.OxiServi.Commands.Orden
{
    [DataContract]
    public class UpdateEstadoOrdenCommand : IRequest<int>
    {
        [DataMember]
        public int OrdenId { get; set; }
        [DataMember]
        public int EstadoOrdenId { get; set; }
    }
}
