using Domain.OxiServi.AggregatesModel.DistritoAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OxiServi.Commands.Distrito
{
    public class DeleteDistritoCommandHandler:IRequestHandler<DeleteDistritoCommand,int>
    {
        public IDistritoRepository _distritoRepository;
        public DeleteDistritoCommandHandler(IDistritoRepository distritoRepository)
        {
            _distritoRepository = distritoRepository;
        }
        public async Task<int> Handle(DeleteDistritoCommand request, CancellationToken cancellationToken)
        {
            var model = new Domain.OxiServi.AggregatesModel.DistritoAggregate.Distrito();
            model.DeleteDistrito(request.idDistrito);
            return await _distritoRepository.DeleteDistrito(model);
        }
    }
}
