﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.OxiServi.Commands.DetalleOrden
{
    [DataContract]
    public class DevolverProductoCommand : IRequest<int>
    {
        [DataMember]
        public int idDetalleOrden { get; set; }
        [DataMember]
        public bool isDañado { get; set; }
        [DataMember]
        public string comentario { get; set; }
    }
}