using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.OxiServi.AggregatesModel.DistritoAggregate
{
    public interface IDistritoRepository
    {
        Task<int> CreateDistrito(Distrito distrito);
        Task<int> DeleteDistrito(Distrito distrito);
        Task<int> DesactivateDistrito(Distrito distrito);
    }
}
