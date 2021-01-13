using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.Northwind.Commands.Category
{
    public class CreateProductCommand : IRequest<int>
    {
        [DataMember]
        public string CategoryName { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}
