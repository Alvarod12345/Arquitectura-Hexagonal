using Domain.OxiServi.AggregatesModel.DetalleOrdenAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OxiServi.Commands.DetalleOrden
{
    public class DetalleOrdenCommandHandler : IRequestHandler<DetalleOrdenCommand, int>
    {
        public IDetalleOrdenRepository _detalleOrdenRepository;
        public DetalleOrdenCommandHandler(IDetalleOrdenRepository detalleOrden)
        {
            _detalleOrdenRepository = detalleOrden;
        }
        public async Task<int> Handle(DetalleOrdenCommand request, CancellationToken cancellationToken)
        {
            var modelo = new Domain.OxiServi.AggregatesModel.DetalleOrdenAggregate.DetalleOrden();
            modelo.Update(request.idDetalleOrden,request.comentario);
            var result = await _detalleOrdenRepository.Update(modelo);
            return result;
        }       
    }

}
