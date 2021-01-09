using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.OxiServi.Commands.Recarga
{
    [DataContract]
    public class DeleteProductoRecargaCommand : IRequest<int>
    {
        [DataMember]
        public int idRecarga { get; set; }
        [DataMember]
        public int idProducto { get; set; }
    }
}
