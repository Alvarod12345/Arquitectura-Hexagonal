using Domain.Northwind.AggregatesModel.ProductAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Northwind.Commands.Product
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
    {
        public IProductRepository _productRepository;
        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var model = new Domain.Northwind.AggregatesModel.ProductAggregate.Product();
            model.Update(request.ProductID,request.ProductName, request.SupplierID, request.CategoryID, request.QuantityPerUnit, request.UnitPrice, request.UnitsInStock, request.UnitsOnOrder, request.ReorderLevel, request.Discontinued);

            int validation = 0;
            if (validation >= default(int))
                return await _productRepository.Update(model);
            else
                return validation;
        }
    }
}
