using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OxiServi.Queries.Auth
{
    public class AuthViewModel
    {
        public int IdUsuario { get; set; }
        public int IdDetalleUsuario { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string NumDocumento { get; set; }
        public int TipDocumento { get; set; }
        public string Telefono { get; set; }
        public int idRol { get; set; }

    }
}
