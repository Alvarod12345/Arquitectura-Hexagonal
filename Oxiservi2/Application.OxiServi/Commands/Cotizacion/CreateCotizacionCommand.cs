using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.OxiServi.Commands.Cotizacion
{
    [DataContract]
    public class CreateCotizacionCommand:IRequest<int>
    {
        [DataMember]
        public List<Producto> listaproductos { get; set; }
        [DataMember]
        public int idCliente { get; set; }
        [DataMember]
        public float Monto{ get; set; }
        [DataMember]
        public int idDireccion { get; set; }
    }
    
    [DataContract]
    public class Producto
    {
        [DataMember]
        public int ProductoId { get; set; }
        [DataMember]
        public int ImplementoId { get; set; }
    }
}
