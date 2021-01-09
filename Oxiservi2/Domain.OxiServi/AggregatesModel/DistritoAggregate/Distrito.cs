using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.OxiServi.AggregatesModel.DistritoAggregate
{
    public class Distrito
    {
        public int idDistrito { get; set; }
        public string nombre { get; set; }
        public float monto { get; set; }
        public int result { get; set; }
        
        public void CreateDistrito(string nombre,float monto)
        {
            this.nombre = nombre;
            this.monto = monto;
        }
        public void DeleteDistrito(int idDistrito)
        {
            this.idDistrito = idDistrito;
        }
        public void DesactivateDistrito(int idDistrito)
        {
            this.idDistrito = idDistrito;
        }
    }
}
