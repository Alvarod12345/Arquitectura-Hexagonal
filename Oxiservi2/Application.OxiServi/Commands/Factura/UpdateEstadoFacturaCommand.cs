using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;


namespace Application.OxiServi.Commands.Factura
{
    [DataContract]
    public class UpdateEstadoFacturaCommand : IRequest<int>
    {
        [DataMember]
        public int ComprobanteId { get; set; }

    }
}
