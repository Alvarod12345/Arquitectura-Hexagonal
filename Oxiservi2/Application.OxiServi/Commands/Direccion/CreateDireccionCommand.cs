using Domain.OxiServi.AggregatesModel.DireccionAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.OxiServi.Commands.Direccion
{
    [DataContract]
    public class CreateDireccionCommand : IRequest<int>
    {
        [DataMember]
        public int idDistrito { get; set; }
        [DataMember]
        public int idCliente { get; set; }
        [DataMember]
        public string lote { get; set; }
        [DataMember]
        public string urbanizacion { get; set; }
        [DataMember]
        public string referencia { get; set; }
        [DataMember]
        public string descripcion { get; set; }
        [DataMember]
        public double latitud { get; set; }
        [DataMember]
        public double longitud { get; set; }
    }
}
