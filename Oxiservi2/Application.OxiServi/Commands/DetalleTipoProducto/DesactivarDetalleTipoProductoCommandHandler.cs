using Domain.OxiServi.AggregatesModel.DetalleTipoProductoAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OxiServi.Commands.DetalleTipoProducto
{
    public class DesactivarDetalleTipoProductoCommandHandler : IRequestHandler<DesactivarDetalleTipoProductoCommand, int>
    {
        public IDetalleTipoProductoRepository _detalleTipoProductoRepository;
        public DesactivarDetalleTipoProductoCommandHandler(IDetalleTipoProductoRepository detalleTipoProductoRepository)
        {
            _detalleTipoProductoRepository = detalleTipoProductoRepository;
        }
        public async Task<int> Handle(DesactivarDetalleTipoProductoCommand request, CancellationToken cancellationToken)
        {
            var model = new Domain.OxiServi.AggregatesModel.DetalleTipoProductoAggregate.DetalleTipoProducto();
            model.DesactivarDetalleTipoProducto(request.idTipoProducto);
            return await _detalleTipoProductoRepository.DesactivarDetalleTipoProducto(model);
        }

    }
}
