﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.Northwind.Commands.Product
{
    [DataContract]
    public class UpdateProductCommand : IRequest<int>
    {
        [DataMember]
        public int ProductID { get; set; }
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
        public int ReoderLevel { get; set; }
        [DataMember]
        public bool Discontinued { get; set; }
    }
}
