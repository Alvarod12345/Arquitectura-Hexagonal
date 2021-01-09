using Domain.OxiServi.AggregatesModel.RecargaAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OxiServi.Commands.Recarga
{
    public class DeleteProductoRecargaCommandHandler : IRequestHandler<DeleteProductoRecargaCommand, int>
    {
        public IRecargaRepository _recargaRepository;
        public DeleteProductoRecargaCommandHandler(IRecargaRepository recargaRepository)
        {
            _recargaRepository = recargaRepository;
        }
        public async Task<int> Handle(DeleteProductoRecargaCommand request, CancellationToken cancellationToken)
        {
            return await _recargaRepository.DeleteProductoRecarga(request.idRecarga,request.idProducto);
        }
    }
}
