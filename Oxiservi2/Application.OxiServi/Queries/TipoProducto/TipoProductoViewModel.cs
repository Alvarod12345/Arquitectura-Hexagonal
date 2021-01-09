using Application.OxiServi.Queries.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OxiServi.Queries.TipoProducto
{
    public class TipoProductoViewModel
    {
        public string Nombre { get; set; }
    }
    public class filterTipoProductoViewModel : FilterBaseViewModel
    {

    }
    public class TipoProductoPaginado
    {
        public int Total { get; set; }
        public IEnumerable<TipoProductoViewModel> TipoProducto { get; set; }
    }
}
