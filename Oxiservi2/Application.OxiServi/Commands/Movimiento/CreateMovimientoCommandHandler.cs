using Domain.OxiServi.AggregatesModel.MovimientoAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OxiServi.Commands.Movimiento
{
    public class CreateMovimientoCommandHanlder : IRequestHandler<CreateMovimientoCommand, int>
    {
        public IMovimientoRepository _movimientoRepository;
        public CreateMovimientoCommandHanlder(IMovimientoRepository movimientoRepository)
        {
            _movimientoRepository = movimientoRepository;
        }
        public async Task<int> Handle(CreateMovimientoCommand request, CancellationToken cancellationToken)
        {
            var model = new Domain.OxiServi.AggregatesModel.MovimientoAggregate.Movimiento();
            model.Create(request.idTipoMovimiento, DateTime.ParseExact(request.FechaSalida, "dd/MM/yyyy", null), DateTime.ParseExact(request.FechaEntrada, "dd/MM/yyyy", null));
            return await _movimientoRepository.Create(model);
        }
    }
}
