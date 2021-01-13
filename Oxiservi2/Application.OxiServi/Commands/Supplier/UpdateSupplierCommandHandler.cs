using Domain.OxiServi.AggregatesModel.SuppliersAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Northwind.Commands.Supplier
{
    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, int>
    {
        public ISupplierRepository _supplierRepository;

        public UpdateSupplierCommandHandler(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }
        public async Task<int> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var model = new Domain.OxiServi.AggregatesModel.SuppliersAggregate.Supplier();
            model.Update(request.SupplierId, request.CompanyName, request.ContactName, request.ContactTitle, request.Address, request.City, request.Region, request.PostalCode, request.Country, request.Phone, request.Fax, request.HomePage);
            return await _supplierRepository.Update(model);
        }
    }
}
