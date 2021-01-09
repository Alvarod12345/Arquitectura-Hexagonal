using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.OxiServi.Commands.Distrito
{
    [DataContract]
    public class DeleteDistritoCommand:IRequest<int>
    {
        [DataMember]
        public int idDistrito { get; set; }
    }
}
