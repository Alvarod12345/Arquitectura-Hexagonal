using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.OxiServi.Queries.Movimiento
{
    public interface IMovimientoQueries
    {
       Task<IEnumerable<MovimientoViewModel>> GetAll();
        Task<MovimientoPaginado> GetAllPaginado(ListarMovimientoViewModel listarParameter);
        Task<MovimientoDetalle> GetMovimientoDetalle(ListarMovimientoViewModel listarParameter);
    }
}
