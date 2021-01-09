using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.OxiServi.Queries.Cotizacion
{
    public interface ICotizacionQueries
    {
        Task<PaginaCotizacionPaginado> GetAllCotizacionPaginado(CotizacionPaginationFilter filter);
        Task<Cotizacion> GetCotizacionById(int idCotizacion);
    }
}
