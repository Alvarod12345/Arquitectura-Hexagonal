using Application.OxiServi.Queries.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.OxiServi.Queries.Factura
{
    public interface IFacturaQueries
    {
        Task<IEnumerable<FacturaViewModel>> GetAll();
        Task<FacturaPaginado> GetAllPaginado(ListarFacturaViewModel listarParameter);
    }
}
