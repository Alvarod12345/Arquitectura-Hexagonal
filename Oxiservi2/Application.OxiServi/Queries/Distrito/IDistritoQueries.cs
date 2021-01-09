using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.OxiServi.Queries.Distrito
{
    public interface IDistritoQueries
    {
        Task<DistritoPaginado> GetAllPagination(filterDistritoViewModel filter);
    }
}
