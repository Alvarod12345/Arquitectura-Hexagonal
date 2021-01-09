using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.OxiServi.Commands.Recarga
{
    [DataContract]
    public class GenerarRecargaCommand : IRequest<int>
    {
        [DataMember]
        public int idRecarga { get; set; }
        [DataMember]
        public int idProveedor { get; set; }
        [DataMember]
        public List<Prod> prodList { get; set; }
    }
    public class Prod
    {
        public int prod { get; set; }
    }
}
