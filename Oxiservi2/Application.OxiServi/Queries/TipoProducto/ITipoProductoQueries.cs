using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.OxiServi.Queries.TipoProducto
{
    public interface ITipoProductoQueries
    {
        Task<TipoProductoPaginado> GetAllPagination(filterTipoProductoViewModel filter);
    }
}
