using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.OxiServi.Queries.Auth
{
    public interface IAuthQueries
    {
        Task<IEnumerable<AuthViewModel>> GetUserById(int idUsuario);
    }
}
