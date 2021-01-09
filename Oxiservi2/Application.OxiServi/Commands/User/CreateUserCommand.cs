using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.OxiServi.Commands.User
{
    [DataContract]
    public class CreateUserCommand : IRequest<int>
    {
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Paterno { get; set; }
        [DataMember]
        public string Materno { get; set; }
        [DataMember]
        public string NumDocumento { get; set; }
        [DataMember]
        public int TipoDocumento { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Contrasena { get; set; }
        [DataMember]
        public int IdRol { get; set; }


    }
}
