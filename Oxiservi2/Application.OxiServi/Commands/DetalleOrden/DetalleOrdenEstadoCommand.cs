using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.OxiServi.Commands.DetalleOrden
{
    [DataContract]
    public class DetalleOrdenEstadoCommand : IRequest<int>
    {
        //[DataMember]
        //public List<ListaDetalleOrden> listaDetalleOrden{get;set;}
        [DataMember]
        public int idDetalleOrden { get; set; }
        [DataMember]
        public int idEstadoOrden { get; set; }
    }
    //public class ListaDetalleOrden
    //{
    //    [DataMember]
    //    public int idDetalleOrden { get; set; }
    //    [DataMember]
    //    public int idEstadoDetalleOrden { get; set; }
    //}
}
