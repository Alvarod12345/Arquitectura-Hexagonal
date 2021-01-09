﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.OxiServi.Commands.Implemento
{
    [DataContract]
    public class DeleteImplementoCommand:IRequest<int>
    {
        [DataMember]
        public int Implementoid { get; set; }
    }
}