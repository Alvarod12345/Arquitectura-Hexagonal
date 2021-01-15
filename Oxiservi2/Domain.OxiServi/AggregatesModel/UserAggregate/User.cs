using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.OxiServi.AggregatesModel.UserAggregate
{
    public class User
    {
        public int idUsuario { get; set; }
        public string nombre { get; set; }
        public string paterno { get; set; }
        public string materno { get; set; }
        public string numDocumento { get; set; }
        public string contrasena { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }


        public void Create(string nombre, string paterno, string materno, string numDocumento, string email, string contrasena, string telefono)
        {
            this.nombre = nombre;
            this.paterno = paterno;
            this.materno = materno;
            this.numDocumento = numDocumento;
            this.telefono = telefono;
            this.email = email;
            this.contrasena = contrasena;

        }
        public void Update(int idUsuario, string nombre, string paterno, string materno, string numDocumento, string telefono, string email, string contrasena)
        {
            this.idUsuario = idUsuario;
            this.nombre = nombre;
            this.paterno = paterno;
            this.materno = materno;
            this.numDocumento = numDocumento;
            this.telefono = telefono;
            this.email = email;
            this.contrasena = contrasena;

        }
        public void Delete(int idUsuario)
        {
            this.idUsuario = idUsuario;
        }
    }

}
