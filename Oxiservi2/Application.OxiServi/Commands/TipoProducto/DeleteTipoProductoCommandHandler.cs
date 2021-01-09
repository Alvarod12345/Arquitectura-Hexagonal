using Domain.OxiServi.AggregatesModel.TipoProductoAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OxiServi.Commands.TipoProducto
{
    public class DeleteTipoProductoCommandHandler:IRequestHandler<DeleteTipoProductoCommand,int>
    {
        public ITipoProductoRepository _tipoproductoRepository;
        public DeleteTipoProductoCommandHandler(ITipoProductoRepository tipoproductoRepository)
        {
            _tipoproductoRepository = tipoproductoRepository;
        }
        public async Task<int> Handle(DeleteTipoProductoCommand request, CancellationToken cancellationToken)
        {
            var model = new Domain.OxiServi.AggregatesModel.TipoProductoAggregate.TipoProducto();
            model.DeleteTipoProducto(request.idTipoProducto);
            return await _tipoproductoRepository.DeleteTipoProducto(model);
        }
    }
}
