using Domain.OxiServi.AggregatesModel.ProductoAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OxiServi.Commands.Producto
{
    public class DesactivarProductoCommandHandler : IRequestHandler<DesactivarProductoCommand,bool>
    {
        public IProductoRepository _productoRepository;
        public DesactivarProductoCommandHandler(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<bool> Handle(DesactivarProductoCommand request, CancellationToken cancellationToken)
        {
            var model = new Domain.OxiServi.AggregatesModel.ProductoAggregate.Producto();
            model.Desactivar(request.idProducto);
            return await _productoRepository.DesactivarProducto(model);
        }
    }
}
