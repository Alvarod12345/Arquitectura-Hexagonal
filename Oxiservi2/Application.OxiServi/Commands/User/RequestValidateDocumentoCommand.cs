using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.OxiServi.Commands.User
{
    [DataContract]
    public class RequestValidateDocumentoCommand : IRequest<bool>
    {
        [DataMember]
        public int tipoDocumento { get; set; }
        [DataMember]
        public string numDocumento { get; set; }
    }
}
