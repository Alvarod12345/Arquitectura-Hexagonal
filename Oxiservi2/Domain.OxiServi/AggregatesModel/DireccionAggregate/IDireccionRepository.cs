using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.OxiServi.AggregatesModel.DireccionAggregate
{
    public interface IDireccionRepository
    {
        Task<int> Create(Direccion direccion);
        Task<int> Active(Direccion direccion);
        Task<int> Delete(Direccion direccion);
    }
}
