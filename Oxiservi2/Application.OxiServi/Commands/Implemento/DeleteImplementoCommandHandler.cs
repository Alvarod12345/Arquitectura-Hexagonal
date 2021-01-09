using Domain.OxiServi.AggregatesModel.ImplementoAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OxiServi.Commands.Implemento
{
    public class DeleteImplementoCommandHandler:IRequestHandler<DeleteImplementoCommand,int>
    {
        public IImplementoRepository _implementoRepository;
        public DeleteImplementoCommandHandler(IImplementoRepository distritoRepository)
        {
            _implementoRepository = distritoRepository;
        }
        public async Task<int> Handle(DeleteImplementoCommand request, CancellationToken cancellationToken)
        {
            var model = new Domain.OxiServi.AggregatesModel.ImplementoAggregate.Implemento();
            model.DeleteImplemento(request.Implementoid);
            return await _implementoRepository.DeleteImplemento(model);
        }
    }
}
