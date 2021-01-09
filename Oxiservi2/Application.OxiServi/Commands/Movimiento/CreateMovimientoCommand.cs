using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.OxiServi.Commands.Movimiento
{
    [DataContract]
    public class CreateMovimientoCommand : IRequest<int>
    {
        [DataMember]
        public int idTipoMovimiento{ get; set; }
        [DataMember]
        public string FechaSalida { get; set; }
        [DataMember]
        public string FechaEntrada { get; set; }
    }
}
