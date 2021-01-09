using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Domain.OxiServi.AggregatesModel.DetalleOrdenAggregate
{
    public class DetalleOrden
    {
        public int idOrden { get; set; }
        public int idDetalleOrden { get; set; }
        public string comentario { get; set; }
        public int idProducto { get; set; }
        public int idEstadoOrden { get; set; }
        public DateTime fechaCaducidad { get; set; }
        public float Costo { get; set; }
        public string ubicacion { get; set; }
        public int result { get; set; }
        public XmlElement XMLidDetalleOrden { get; set; }
        public bool isDañado { get; set; }

        public void Update(int idDetalleOrden,string comentario)
        {
            this.idDetalleOrden = idDetalleOrden;
            this.comentario = comentario;
        }
        public void UpdateDetalleOrden(int idDetalleOrden, int idEstadoOrden)
        {
            this.idDetalleOrden = idDetalleOrden;
            this.idEstadoOrden = idEstadoOrden;
        }
        public void Devolver(int idDetalleOrden, bool isDañado, string comentario)
        {
            this.idDetalleOrden = idDetalleOrden;
            this.isDañado = isDañado;
            this.comentario = comentario;
        }
    }
}
