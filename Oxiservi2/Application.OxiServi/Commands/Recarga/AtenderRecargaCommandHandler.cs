using Domain.OxiServi.AggregatesModel.RecargaAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OxiServi.Commands.Recarga
{
    public class AtenderRecargaCommandHandler : IRequestHandler<AtenderRecargaCommand, int>
    {
        public IRecargaRepository _recargaRepository;
        public AtenderRecargaCommandHandler(IRecargaRepository recargaRepository)
        {
            _recargaRepository = recargaRepository;
        }
        public async Task<int> Handle(AtenderRecargaCommand request, CancellationToken cancellationToken)
        {
            return await _recargaRepository.AtenderRecarga(request.idRecarga);
        }
    }
}
