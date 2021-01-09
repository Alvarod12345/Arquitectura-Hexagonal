using Domain.OxiServi.AggregatesModel.TipoProductoAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OxiServi.Commands.TipoProducto
{
    public class CreateTipoProductoCommandHandler:IRequestHandler<CreateTipoProductoCommand,int>
    {
        public ITipoProductoRepository _tipoproductoRepository;
        public CreateTipoProductoCommandHandler(ITipoProductoRepository tipoproductoRepository)
        {
            _tipoproductoRepository = tipoproductoRepository;
        }
        public async Task<int> Handle(CreateTipoProductoCommand request, CancellationToken cancellationToken)
        {
            var model = new Domain.OxiServi.AggregatesModel.TipoProductoAggregate.TipoProducto();
            model.CreateTipoProducto(request.Nombre);
            var result = await _tipoproductoRepository.CreateTipoProducto(model);
            return result;
        }
    }
}
