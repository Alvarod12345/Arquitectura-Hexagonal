using Domain.OxiServi.AggregatesModel.DetalleTipoProductoAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OxiServi.Commands.DetalleTipoProducto
{
    public class DeleteDetalleTipoProductoCommandHandler:IRequestHandler<DeleteDetalleTipoProductoCommand,int>
    {
        public IDetalleTipoProductoRepository _detalletipoproductoRepository;
        public DeleteDetalleTipoProductoCommandHandler(IDetalleTipoProductoRepository detalletipoproductoRepository)
        {
            _detalletipoproductoRepository = detalletipoproductoRepository;
        }
        public async Task<int> Handle(DeleteDetalleTipoProductoCommand request, CancellationToken cancellationToken)
        {
            var model = new Domain.OxiServi.AggregatesModel.DetalleTipoProductoAggregate.DetalleTipoProducto();
            model.DeleteDetalleTipoProducto(request.idTipoProducto);
            return await _detalletipoproductoRepository.DeleteDetalleTipoProducto(model);
        }
    }
}
