using CrossCutting.Utility.OxiServi.Extensions;
using Domain.OxiServi.AggregatesModel.CotizacionAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OxiServi.Commands.Cotizacion
{
    public class GenerarOrdenCommandHandler : IRequestHandler<GenerarOrdenCommand, int>
    {
        public ICotizacionRepository _cotizacionRepository;
        public GenerarOrdenCommandHandler(ICotizacionRepository cotizacionRepository)
        {
            _cotizacionRepository = cotizacionRepository;
        }
        public async Task<int> Handle(GenerarOrdenCommand request, CancellationToken cancellationToken)
        {
            var model = new Domain.OxiServi.AggregatesModel.CotizacionAggregate.Cotizacion();
            //var lastNumeroOrden = await _cotizacionRepository.GetLastNumeroOrden();
            var numeroOrden = GenerateNumberComprobante.GenerateNumber("00001");
            model.GenerarOrden(request.CotizacionId,DateTime.ParseExact(request.FechaEntrega,"dd/MM/yyyy",null),request.idTipoComprobante, numeroOrden,request.RUC);
            return await _cotizacionRepository.GenerarOrden(model);
        }
    }
}
