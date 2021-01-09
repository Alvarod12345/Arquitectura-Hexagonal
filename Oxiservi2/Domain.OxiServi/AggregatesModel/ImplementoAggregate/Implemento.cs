using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.OxiServi.AggregatesModel.ImplementoAggregate
{
    public class Implemento
    {
        public int ImplementoId { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public int result { get; set; }

        public void CreateImplemento(string Descripcion,float Precio)
        {
            this.Descripcion = Descripcion;
            this.Precio = Precio;
        }
        public void DesactivateImplemento(int ImplementoId)
        {
            this.ImplementoId = ImplementoId;
        }
        public void DeleteImplemento(int ImplementoId)
        {
            this.ImplementoId = ImplementoId;
        }
    }
}
