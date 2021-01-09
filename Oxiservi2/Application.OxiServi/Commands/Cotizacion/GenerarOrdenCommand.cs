using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.OxiServi.Commands.Cotizacion
{
    [DataContract]
    public class GenerarOrdenCommand : IRequest<int>
    {
        [DataMember]
        public int CotizacionId { get; set; }
        [DataMember]
        public int idTipoComprobante { get; set; }
        [DataMember]
        public string RUC { get; set; }
        [DataMember]
        public string FechaEntrega { get; set; }
    }
}
