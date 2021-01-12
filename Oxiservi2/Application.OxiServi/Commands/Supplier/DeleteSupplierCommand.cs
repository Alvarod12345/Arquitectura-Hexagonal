using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.Northwind.Commands.Supplier 
{
    public class DeleteSupplierCommand : IRequest<int>
    {
        [DataMember]
        public int SupplierId { get; set; }
    }
}
