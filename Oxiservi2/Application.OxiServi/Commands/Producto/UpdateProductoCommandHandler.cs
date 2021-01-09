using Domain.OxiServi.AggregatesModel.ProductoAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OxiServi.Commands.Producto
{
    public class UpdateProductoCommandHandler : IRequestHandler<UpdateProductoCommand, int>
    {
        public IProductoRepository _productoRepository;
        public UpdateProductoCommandHandler(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }
        public async Task<int> Handle(UpdateProductoCommand request, CancellationToken cancellationToken)
        {
            var model = new Domain.OxiServi.AggregatesModel.ProductoAggregate.Producto();
            model.Update(request.idProducto, request.Serie, request.idProveedor,
                        request.idDetalleTipoProducto,request.Descripcion,request.Capacidad, 
                        DateTime.ParseExact(request.fechaFabricacion,"dd/MM/yyyy",null),
                         DateTime.ParseExact(request.fechaCaducidad, "dd/MM/yyyy", null),
                         request.Costo);
            return await _productoRepository.Update(model);
        }
    }
}
