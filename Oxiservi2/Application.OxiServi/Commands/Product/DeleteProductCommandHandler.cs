using Domain.Northwind.AggregatesModel.ProductAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Northwind.Commands.Product
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, int>
    {
        public IProductRepository _productRepository;
        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var model = new Domain.Northwind.AggregatesModel.ProductAggregate.Product();
            model.Delete(request.ProductID);

            int validation = 0;
            if (validation >= default(int))
                return await _productRepository.Delete(model);
            else
                return validation;
        }
    }
}
