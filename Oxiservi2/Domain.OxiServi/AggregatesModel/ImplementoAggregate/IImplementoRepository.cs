using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.OxiServi.AggregatesModel.ImplementoAggregate
{
    public interface IImplementoRepository
    {
        Task<int> CreateImplemento(Implemento implemento);
        Task<int> DesactivateImplemento(Implemento implemento);
        Task<int> DeleteImplemento(Implemento implemento);
    }
}
