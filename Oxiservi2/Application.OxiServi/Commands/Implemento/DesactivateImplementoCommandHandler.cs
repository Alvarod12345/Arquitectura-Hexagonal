using Domain.OxiServi.AggregatesModel.ImplementoAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OxiServi.Commands.Implemento
{
    public class DesactivateImplementoCommandHandler:IRequestHandler<DesactivateImplementoCommand,int>
    {
        public IImplementoRepository _implementoRepository;
        public DesactivateImplementoCommandHandler(IImplementoRepository implementoRepository)
        {
            _implementoRepository = implementoRepository;
        }
        public async Task<int> Handle(DesactivateImplementoCommand request, CancellationToken cancellationToken)
        {
            var model = new Domain.OxiServi.AggregatesModel.ImplementoAggregate.Implemento();
            model.DesactivateImplemento(request.Implementoid);
            return await _implementoRepository.DesactivateImplemento(model);
        }
    }
}
