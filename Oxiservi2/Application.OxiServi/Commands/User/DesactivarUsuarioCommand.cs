using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.OxiServi.Commands.User
{
    [DataContract]
    public class DesactivarUsuarioCommand : IRequest<int>
    {
        [DataMember]
        public int idUsuario { get; set; }
    }
}
