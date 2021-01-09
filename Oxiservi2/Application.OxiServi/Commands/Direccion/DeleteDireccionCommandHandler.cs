using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Domain.OxiServi.AggregatesModel.DireccionAggregate;

namespace Application.OxiServi.Commands.Direccion
{
 public class DeleteDireccionCommandHandler : IRequestHandler<DeleteDireccionCommand, int>
    {
        public IDireccionRepository _direccionRepository;
        public DeleteDireccionCommandHandler(IDireccionRepository direccionRepository)
        {
            _direccionRepository = direccionRepository;
        }
        public async Task<int> Handle(DeleteDireccionCommand request, CancellationToken cancellationToken)
        {
            var model = new Domain.OxiServi.AggregatesModel.DireccionAggregate.Direccion();
            model.Delete(request.idDireccion);
            return await _direccionRepository.Delete(model);
        }
    }   
}
