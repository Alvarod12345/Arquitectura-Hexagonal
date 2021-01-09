using Domain.OxiServi.AggregatesModel.TipoProductoAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OxiServi.Commands.TipoProducto
{
    public class DesactivateTipoProductoCommandHandler:IRequestHandler<DesactivateTipoProductoCommand,int>
    {
        public ITipoProductoRepository _tipoproductoRepository;
        public DesactivateTipoProductoCommandHandler(ITipoProductoRepository tipoproductoRepository)
        {
            _tipoproductoRepository = tipoproductoRepository;
        }
        public async Task<int> Handle(DesactivateTipoProductoCommand request, CancellationToken cancellationToken)
        {
            var model = new Domain.OxiServi.AggregatesModel.TipoProductoAggregate.TipoProducto();
            model.DesactivateTipoProducto(request.idTipoProducto);
            return await _tipoproductoRepository.DesactivateTipoProducto(model);
        }
    }
}
