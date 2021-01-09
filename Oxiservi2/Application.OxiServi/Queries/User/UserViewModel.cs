using Application.OxiServi.Queries.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OxiServi.Queries.User
{
    public class UserViewModel
    {
        public int idUsuario { get; set; }
        public string nombre { get; set; }
        public string paterno { get; set; }
        public string materno { get; set; }
        public string telefono { get; set; }
        public string descripcion { get; set; }
        public string email { get; set; }
        public int idRol { get; set; }
        public string contraseña { get; set; }
        public bool isActive { get; set; }
        public int tipDoc { get; set; }
        public string numDoc { get; set; }
    }
    public class ListarUsuarioByNameParameter
    {
        public string nombre { get; set; }
    }
    public class ListarUsuarioByIdParameter
    {
        public int idUsuario { get; set; }
    }

    public class ListarPaginadoParameters : FilterBaseViewModel
    {
        public int idRol { get; set; }
        public int tipDoc { get; set; }
        public string numDoc { get; set; }
    }

    public class UsuarioPaginado 
    {
        public int Total { get; set; }
        public IEnumerable<UserViewModel> users { get; set; }
    }
}
