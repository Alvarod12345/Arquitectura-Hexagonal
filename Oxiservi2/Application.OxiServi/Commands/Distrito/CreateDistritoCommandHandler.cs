using Domain.OxiServi.AggregatesModel.DistritoAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OxiServi.Commands.Distrito
{
    public class CreateDistritoCommandHandler:IRequestHandler<CreateDistritoCommand,int>
    {
        public IDistritoRepository _distritoRepository;
        public CreateDistritoCommandHandler(IDistritoRepository distritoRepository)
        {
            _distritoRepository = distritoRepository;
        }
        public async Task<int> Handle(CreateDistritoCommand request, CancellationToken cancellationToken)
        {
            var model = new Domain.OxiServi.AggregatesModel.DistritoAggregate.Distrito();
            model.CreateDistrito(request.nombre, request.monto);
            var result = await _distritoRepository.CreateDistrito(model);
            return result;
        }
    }
}
