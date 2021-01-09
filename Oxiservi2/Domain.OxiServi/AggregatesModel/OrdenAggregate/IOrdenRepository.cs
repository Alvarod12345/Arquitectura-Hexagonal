using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.OxiServi.AggregatesModel.OrdenAggregate
{
    public interface IOrdenRepository
    {
        Task<int> UpdateEstado(Orden orden,DateTime today);
        Task<int> CancelarOrden(int idOrden, DateTime today);
    }
}
