using Domain.OxiServi.AggregatesModel.SuppliersAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static CrossCutting.Utility.OxiServi.Constants.ApplicationConstants;

namespace Application.OxiServi.Commands.Supplier
{
    public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, int>
    {
        public ISupplierRepository _supplierRepository;
        public CreateSupplierCommandHandler(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<int> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            var model = new Domain.OxiServi.AggregatesModel.SuppliersAggregate.Supplier();
            model.Create(request.CompanyName, request.ContactName, request.ContactTitle, request.Address, request.City, request.Region, request.PostalCode, request.Country, request.Phone, request.Fax, request.HomePage);

            int validation = 0;
            if (validation >= default(int))
                return await _supplierRepository.Create(model);
            else
                return validation;
        }
    }
}
