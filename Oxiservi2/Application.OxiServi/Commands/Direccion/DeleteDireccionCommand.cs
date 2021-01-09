using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.OxiServi.Commands.Direccion
{
    public class DeleteDireccionCommand : IRequest<int>
    {
        [DataMember]
        public int idDireccion { get; set; }
    }
}
