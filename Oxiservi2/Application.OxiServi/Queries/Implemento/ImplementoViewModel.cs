using Application.OxiServi.Queries.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OxiServi.Queries.Implemento
{
    public class ImplementoViewModel
    {
        public string Descripcion { get; set; }
        public double Precio { get; set; }
    }
    public class filterImplementoViewModel:FilterBaseViewModel
    {

    }
    public class ImplementoPaginado
    {
        public int Total { get; set; }
        public IEnumerable<ImplementoViewModel> Implemento { get; set; }
    }
}
