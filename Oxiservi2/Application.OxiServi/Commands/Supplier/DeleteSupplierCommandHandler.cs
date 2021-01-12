using Domain.OxiServi.AggregatesModel.SuppliersAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

namespace Application.Northwind.Commands.Supplier
{
    public class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommand, int>
    {
        public ISupplierRepository _supplierRepository;

        public DeleteSupplierCommandHandler(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }
        public async Task<int> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
        {
            var model = new Domain.OxiServi.AggregatesModel.SuppliersAggregate.Supplier();
            model.Delete(request.SupplierId);
            return await _supplierRepository.Delete(model);
        }
    }
}
