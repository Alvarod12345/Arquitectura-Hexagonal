using Domain.OxiServi.AggregatesModel.DetalleTipoProductoAggregate;
using System;
using MediatR;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OxiServi.Commands.DetalleTipoProducto
{
    public class CreateDetalleTipoProductoCommandHandler : IRequestHandler<CreateDetalleTipoProductoCommand, int>
    {
        public IDetalleTipoProductoRepository _detalleTipoProductoRepository;
        public CreateDetalleTipoProductoCommandHandler(IDetalleTipoProductoRepository detalleTipoProductoRepository)
        {
            _detalleTipoProductoRepository = detalleTipoProductoRepository;
        }
        public async Task<int> Handle(CreateDetalleTipoProductoCommand request, CancellationToken cancellationToken)
        {
            var model = new Domain.OxiServi.AggregatesModel.DetalleTipoProductoAggregate.DetalleTipoProducto();
            model.CreateDetalleProducto(request.descripcion,request.idTipoProducto);
            var result = await _detalleTipoProductoRepository.CreateDetalleTipoProducto(model);
            return result;
        }
    }
}
