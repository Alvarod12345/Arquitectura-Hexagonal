using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OxiServi.Queries.Recarga
{
    public class RecargaViewModel
    {
        public int idRecargaProducto { get; set; }
        public int idRecarga { get; set; }
        public int idProducto { get; set; }
        public string serie { get; set; }
        public bool isActive { get; set; }
    }
    public class RecargaByIdViewModel
    {
        public int idRecarga { get; set; }
        public List<Producto.ProductoRecargaViewModel> productos { get; set; }
    }
}
