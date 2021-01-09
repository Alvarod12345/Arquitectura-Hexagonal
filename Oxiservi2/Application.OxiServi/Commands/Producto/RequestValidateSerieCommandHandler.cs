using Domain.OxiServi.AggregatesModel.ProductoAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OxiServi.Commands.Producto
{
    public class RequestValidateSerieCommandHandler : IRequestHandler<RequestValidateSerieCommand, bool>
    {
        public IProductoRepository _productoRepository;
        public RequestValidateSerieCommandHandler(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }
        public async Task<bool> Handle(RequestValidateSerieCommand request, CancellationToken cancellationToken)
        {
            return await _productoRepository.ValidateSerie(request.Serie);
        }
    }
}
