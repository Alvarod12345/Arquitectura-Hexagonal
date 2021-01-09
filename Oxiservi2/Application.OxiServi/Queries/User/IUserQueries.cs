using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.OxiServi.Queries.User
{
    public interface IUserQueries
    {
        Task<IEnumerable<UserViewModel>> GetAll();
        Task<IEnumerable<UserViewModel>> GetUsuarioById(ListarUsuarioByIdParameter idParameter);
        Task<IEnumerable<UserViewModel>> GetUsuarioByName(ListarUsuarioByNameParameter nameParameter);
        Task<UsuarioPaginado> GetAllPaginado(ListarPaginadoParameters paginado);
    }
}
