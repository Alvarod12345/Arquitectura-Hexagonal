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
    public class CancelarOrdenCommandHandler : IRequestHandler<CancelarOrdenCommand, int>
    {
        public IOrdenRepository _ordenRepository;
        public CancelarOrdenCommandHandler(IOrdenRepository ordenRepository)
        {
            _ordenRepository = ordenRepository;
        }
        public async Task<int> Handle(CancelarOrdenCommand request, CancellationToken cancellationToken)
        {
            return await _ordenRepository.CancelarOrden(request.idOrden, DateExtensions.GetDate());
        }
    }
}
