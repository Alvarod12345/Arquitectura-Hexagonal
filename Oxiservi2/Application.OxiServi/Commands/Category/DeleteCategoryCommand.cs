using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.Northwind.Commands.Category
{
    public class DeleteCategoryCommand : IRequest<int>
    {
        [DataMember]
        public int CategoryID { get; set; }
    }
}
