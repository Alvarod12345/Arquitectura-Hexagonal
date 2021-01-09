using Domain.OxiServi.AggregatesModel.DetalleOrdenAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.OxiServi.Commands.DetalleOrden
{
    public class DetalleOrdenEstadoCommandHandler : IRequestHandler<DetalleOrdenEstadoCommand,int>
    {
        public IDetalleOrdenRepository _detalleOrdenRepository;
        public DetalleOrdenEstadoCommandHandler(IDetalleOrdenRepository detalleOrdenEstado)
        {
            _detalleOrdenRepository = detalleOrdenEstado;
        }
        public async Task<int> Handle(DetalleOrdenEstadoCommand request, CancellationToken cancellationToken)
        {
            
            var modelo = new Domain.OxiServi.AggregatesModel.DetalleOrdenAggregate.DetalleOrden();
            modelo.UpdateDetalleOrden(request.idDetalleOrden,request.idEstadoOrden);
            var result = await _detalleOrdenRepository.UpdateDetalleOrden(modelo);
            return result;
        }

    }
}
