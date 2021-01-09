using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.OxiServi.Queries.DetalleOrden
{
    public interface IDetalleOrdenQueries
    {
        Task<IEnumerable<DetalleOrdenViewModel>> GetAllPagination(FilterDetalleOrdenViewModel filter);
        Task<OrdenMobileViewModel> GetDetalleOrdenByIdOrdenMobile(int idOrden);
    }
}
