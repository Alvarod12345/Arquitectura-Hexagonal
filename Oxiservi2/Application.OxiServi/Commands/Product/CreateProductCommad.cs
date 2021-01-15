using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.Northwind.Commands.Product
{
    [DataContract]
    public class CreateProductCommad : IRequest<int>
    {
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public int SupplierID { get; set; }
        [DataMember]
        public int CategoryID { get; set; }
        [DataMember]
        public string QuantityPerUnit { get; set; }
        [DataMember]
        public double UnitPrice { get; set; }
        [DataMember]
        public int UnitsInStock { get; set; }
        [DataMember]
        public int UnitsOnOrder { get; set; }
        [DataMember]
        public int ReorderLevel { get; set; }
    }
}
