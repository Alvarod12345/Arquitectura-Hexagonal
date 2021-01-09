using System.Threading;
using System.Threading.Tasks;
using Domain.OxiServi.AggregatesModel.DireccionAggregate;
using MediatR;

namespace Application.OxiServi.Commands.Direccion
{
    public class CreateDireccionCommandHandler : IRequestHandler<CreateDireccionCommand, int>
    {
        public IDireccionRepository _direccionRepository;
        public CreateDireccionCommandHandler(IDireccionRepository direccionRepository)
        {
            _direccionRepository = direccionRepository;
        }
        public async Task<int> Handle(CreateDireccionCommand request, CancellationToken cancellationToken)
        {
            var model = new Domain.OxiServi.AggregatesModel.DireccionAggregate.Direccion();
            model.Create(request.idDistrito, request.idCliente, request.lote, request.urbanizacion, request.referencia, request.descripcion,request.latitud,request.longitud);
            var result = await _direccionRepository.Create(model);
            return result;
        }
    }
}
