using Domain.OxiServi.AggregatesModel.DetalleOrdenAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OxiServi.Commands.DetalleOrden
{
    public class DevolverProductoCommandHandler : IRequestHandler<DevolverProductoCommand, int>
    {
        public IDetalleOrdenRepository _detalleOrdenRepository;
        public DevolverProductoCommandHandler(IDetalleOrdenRepository detalleOrdenRepository)
        {
            _detalleOrdenRepository = detalleOrdenRepository;
        }
        public async Task<int> Handle(DevolverProductoCommand request, CancellationToken cancellationToken)
        {
            var model = new Domain.OxiServi.AggregatesModel.DetalleOrdenAggregate.DetalleOrden();
            model.Devolver(request.idDetalleOrden,request.isDañado,request.comentario);
            return await _detalleOrdenRepository.DevolverProducto(model);
        }
    }
}
