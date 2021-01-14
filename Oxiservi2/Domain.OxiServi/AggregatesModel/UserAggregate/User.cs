using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.OxiServi.AggregatesModel.UserAggregate
{
    public class User
    {
        public int idUsuario { get; set; }
        public int idDetalleUsuario { get; set; }
        public string nombre { get; set; }
        public string paterno { get; set; }
        public string materno { get; set; }
        public string numDocumento { get; set; }
        public int tipoDocumento { get; set; }
        public string contrasena { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public int idRol { get; set; }

        public void Create(string nombre, string paterno, string materno, string numDocumento, int tipoDocumento, string email,string contrasena, string telefono,int idRol)
        {
            this.nombre = nombre;
            this.paterno = paterno;
            this.materno = materno;
            this.numDocumento = numDocumento;
            this.tipoDocumento = tipoDocumento;
            this.telefono = telefono;
            this.email = email;
            this.contrasena = contrasena;
            this.idRol = idRol;
        }
        public void Update(int idUsuario,string nombre, string paterno, string materno, string numDocumento, int tipoDocumento,string telefono, string email, string contrasena, int idRol)
        {
            this.idUsuario = idUsuario;
            this.nombre = nombre;
            this.paterno = paterno;
            this.materno = materno;
            this.numDocumento = numDocumento;
            this.tipoDocumento = tipoDocumento;
            this.telefono = telefono;
            this.email = email;
            this.contrasena = contrasena;
            this.idRol = idRol;
        }
        public void Delete(int idUsuario)
        {
            this.idUsuario = idUsuario;
        }
    }

}
