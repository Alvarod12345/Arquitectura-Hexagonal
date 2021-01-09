using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.OxiServi.Queries.Implemento
{
    public interface IImplementoQueries
    {
        Task<ImplementoPaginado> GetAllPagination(filterImplementoViewModel filter);
    }
}
