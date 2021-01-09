using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.OxiServi.Commands.Auth
{
    [DataContract]
    public class LoginCommand : IRequest<int>
    {
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}
