﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.OxiServi.Commands.Recarga
{
    [DataContract]
    public class AtenderRecargaCommand : IRequest<int>
    {
        [DataMember]
        public int idRecarga { get; set; }
    }
}
