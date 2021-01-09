using Domain.OxiServi.AggregatesModel.DireccionAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OxiServi.Commands.Direccion
{
    public class ActiveDireccionCommandHandler : IRequestHandler<ActiveDireccionCommand, int>
    {
        public IDireccionRepository _direccionRepository;
        public ActiveDireccionCommandHandler(IDireccionRepository direccionRepository)
        {
            _direccionRepository = direccionRepository;
        }
        public async Task<int> Handle(ActiveDireccionCommand request, CancellationToken cancellationToken)
        {
            var model = new Domain.OxiServi.AggregatesModel.DireccionAggregate.Direccion();
            model.Active(request.idDireccion);
            return await _direccionRepository.Active(model);
        }
    }
}
