using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Domain.OxiServi.AggregatesModel.RecargaAggregate
{
    public class Recarga
    {
        public int idRecargaProducto { get; set; }
        public int idRecarga { get; set; }
        public int idProducto { get; set; }
        public string serie { get; set; }
        public bool isActive { get; set; }
        public XElement prod { get; set; }
        public void GenerarRecarga(XElement prod)
        {
            this.prod = prod;
        }
    }
}
