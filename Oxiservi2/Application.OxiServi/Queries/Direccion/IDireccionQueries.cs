using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.OxiServi.Queries.Direccion
{
   public interface IDireccionQueries
   {
        Task<IEnumerable<DireccionViewModel>> GetAll();
        Task<IEnumerable<DireccionViewModel>> GetAllByCliente(int idCliente);
   }
}
