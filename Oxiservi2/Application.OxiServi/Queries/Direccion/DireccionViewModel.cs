using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OxiServi.Queries.Direccion
{
    public class DireccionViewModel
    {
        public int idDireccion { get; set; }
        public int idDistrito { get; set; }
        public string distrito { get; set; }
        public float monto_adicional { get; set; }
        public int idCliente { get; set; }
        public string nombre { get; set; }
        public string lote { get; set; }
        public string urbanizacion { get; set; }
        public string referencia { get; set; }
        public bool isActive { get; set; }
        public string Descripcion { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
    }
}
