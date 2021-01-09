using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.OxiServi.Queries.Orden
{
    public interface IOrdenQueries
    {
        Task<IEnumerable<OrdenViewModel>> GetAllPagination(FilterOrdenViewModel filter);
        Task<OrdenWebPaginationViewModel> GetAllPaginationWeb(FilterOrdenWebViewModel filter);
        Task<IEnumerable<EstadoOrdenViewModel>> GetEstadoDispoible(int estado);
        Task<FacturaOrdenViewModel> GetFacturaByOrden(int idOrden);
    }
}
