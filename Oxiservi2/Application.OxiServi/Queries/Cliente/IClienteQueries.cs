using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.OxiServi.Queries.Cliente
{
    public interface IClienteQueries
    {
        Task<ClientePaginationViewModel> GetAllPagination(FilterClienteViewModel filter);
        Task<IEnumerable<ClientePaginationModel>> GetClienteCotizacion(FilterClienteCotizacionViewModel filter);
    }
}
