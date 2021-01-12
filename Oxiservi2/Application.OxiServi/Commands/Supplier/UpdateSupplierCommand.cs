using Domain.OxiServi.AggregatesModel.SuppliersAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.Northwind.Commands.Supplier
{
    public class UpdateSupplierCommand : IRequest<int>
    {
        [DataMember]
        public int SupplierId { get; set; }
        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public string ContactName { get; set; }
        [DataMember]
        public string ContactTitle { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Region { get; set; }
        [DataMember]
        public string PostalCode { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string Fax { get; set; }
        [DataMember]
        public string HomePage { get; set; }
    }
}
