    using Application.OxiServi.Queries.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OxiServi.Queries.DetalleTipoProducto
{
    public class DetalleTipoProductoViewModel
    {
        public string descripcion { get; set;}
        public int idTipoProducto { get; set; }
    }
    public class filterDetalleTipoProductoViewModel : FilterBaseViewModel
    {

    }
    public class DetalleTipoProductoPaginado
    {
        public int Total { get; set; }
        public IEnumerable<DetalleTipoProductoViewModel> DetalleTipoProducto { get; set; }
    }

}
