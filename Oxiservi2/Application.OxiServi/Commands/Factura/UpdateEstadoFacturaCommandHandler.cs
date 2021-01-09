using Domain.OxiServi.AggregatesModel.FacturaAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OxiServi.Commands.Factura
{
    class UpdateEstadoFacturaCommandHandler : IRequestHandler<UpdateEstadoFacturaCommand, int>
    {
        public IFacturaRepository _facturaRepository;
        public UpdateEstadoFacturaCommandHandler(IFacturaRepository facturaRepository)
        {
            _facturaRepository = facturaRepository;
        }
        public async Task<int> Handle(UpdateEstadoFacturaCommand request, CancellationToken cancellationToken)
        {
            var model = new Domain.OxiServi.AggregatesModel.FacturaAggregate.Factura();
            model.UpdateEstado(request.ComprobanteId);
            return await _facturaRepository.UpdateEstado(model);
        }
    }
}
