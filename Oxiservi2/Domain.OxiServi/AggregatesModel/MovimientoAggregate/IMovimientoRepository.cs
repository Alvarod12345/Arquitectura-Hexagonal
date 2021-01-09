using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.OxiServi.AggregatesModel.MovimientoAggregate
{
    public interface IMovimientoRepository
    {
        Task<int> Create(Movimiento movimiento);
    }
}
