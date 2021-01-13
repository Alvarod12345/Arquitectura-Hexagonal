using Domain.Northwind.AggregatesModel.ProductAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Northwind.Commands.Product
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommad, int>
    {
        public IProductRepository _productRepository;
        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<int> Handle(CreateProductCommad request, CancellationToken cancellationToken)
        {
            var model = new Domain.Northwind.AggregatesModel.ProductAggregate.Product();
            model.Create(request.ProductName,request.SupplierID,request.CategoryID,request.QuantityPerUnit,request.UnitPrice,request.UnitsInStock,request.UnitsOnOrder,request.ReoderLevel);

            int validation = 0;
            if (validation >= default(int))
                return await _productRepository.Create(model);
            else
                return validation;
        }
    }
}
