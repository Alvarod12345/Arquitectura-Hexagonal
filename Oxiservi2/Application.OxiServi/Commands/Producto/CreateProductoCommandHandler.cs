using Domain.OxiServi.AggregatesModel.ProductoAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OxiServi.Commands.Producto
{
    public class CreateProductoCommandHandler : IRequestHandler<CreateProductoCommand, int>
    {
        public IProductoRepository _productoRepository;
        public CreateProductoCommandHandler(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }
        public async Task<int> Handle(CreateProductoCommand request, CancellationToken cancellationToken)
        {
            var model = new Domain.OxiServi.AggregatesModel.ProductoAggregate.Producto();
            model.Create(request.Serie, 
                         request.Descripcion,
                         request.Capacidad,
                         DateTime.ParseExact(request.fechaFabricacion,"dd/MM/yyyy",null),
                         DateTime.ParseExact(request.fechaCaducidad, "dd/MM/yyyy", null),
                         request.Costo,
                         request.IdDetalleTipoProducto,
                         request.idProveedor);
            return await _productoRepository.Create(model);
        }
    }
}
