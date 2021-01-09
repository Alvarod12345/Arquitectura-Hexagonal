using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.OxiServi.Queries.Recarga
{
    public interface IRecargaQueries
    {
        Task<IEnumerable<RecargaViewModel>> GetAll();
        Task<IEnumerable<RecargaViewModel>> GetNoAtendidas();
        Task<RecargaByIdViewModel> GetRecargaById(int idRecarga);
    }
}
