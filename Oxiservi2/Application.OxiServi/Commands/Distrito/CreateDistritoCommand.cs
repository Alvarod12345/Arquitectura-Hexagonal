using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.OxiServi.Commands.Distrito
{
    [DataContract]
    public class CreateDistritoCommand:IRequest<int>
    {
        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public float monto { get; set; }
    }
}
