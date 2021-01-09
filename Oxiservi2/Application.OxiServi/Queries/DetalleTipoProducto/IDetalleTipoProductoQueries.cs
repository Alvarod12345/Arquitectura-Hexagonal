using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.OxiServi.Queries.DetalleTipoProducto
{
    public interface IDetalleTipoProductoQueries
    {
        Task<DetalleTipoProductoPaginado> GetAllPagination(filterDetalleTipoProductoViewModel filter);
    }
}
