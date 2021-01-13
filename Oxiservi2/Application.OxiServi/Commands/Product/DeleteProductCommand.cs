using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.Northwind.Commands.Product
{
    [DataContract]
    public class DeleteProductCommand : IRequest<int>
    {
        [DataMember]
        public int ProductID { get; set; }
    }
}
