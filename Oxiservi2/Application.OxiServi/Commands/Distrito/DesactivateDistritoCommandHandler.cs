using Domain.OxiServi.AggregatesModel.DistritoAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OxiServi.Commands.Distrito
{
    public class DesactivateDistritoCommandHandler:IRequestHandler<DesactivateDistritoCommand,int>
    {
        public IDistritoRepository _distritoRepository;
        public DesactivateDistritoCommandHandler(IDistritoRepository distritoRepository)
        {
            _distritoRepository = distritoRepository;
        }
        public async Task<int> Handle(DesactivateDistritoCommand request, CancellationToken cancellationToken)
        {
            var model = new Domain.OxiServi.AggregatesModel.DistritoAggregate.Distrito();
            model.DesactivateDistrito(request.idDistrito);
            return await _distritoRepository.DesactivateDistrito(model);
        }
    }
}
