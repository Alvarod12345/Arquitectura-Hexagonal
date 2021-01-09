using CrossCutting.Utility.OxiServi.Extensions;
using Domain.OxiServi.AggregatesModel.OrdenAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OxiServi.Commands.Orden
{
    public class UpdateEstadoOrdenCommandHandler : IRequestHandler<UpdateEstadoOrdenCommand, int>
    {
        public IOrdenRepository _ordenRepository;
        public UpdateEstadoOrdenCommandHandler(IOrdenRepository ordenRepository)
        {
            _ordenRepository = ordenRepository;
        }
        public async Task<int> Handle(UpdateEstadoOrdenCommand request, CancellationToken cancellationToken)
        {
            var model = new Domain.OxiServi.AggregatesModel.OrdenAggregate.Orden();
            model.UpdateEstado(request.OrdenId, request.EstadoOrdenId);
            return await _ordenRepository.UpdateEstado(model,DateExtensions.GetDate());
        }
    }
}
