using Application.OxiServi.Queries.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OxiServi.Queries.Distrito
{
    public class DistritoViewModel
    {
        public string nombre { get; set; }
        public double monto_adicional { get; set; }
    }
    public class filterDistritoViewModel : FilterBaseViewModel
    {

    }
    public class DistritoPaginado
    {
        public int Total { get; set; }
        public IEnumerable<DistritoViewModel> Distrito { get; set; }
    }
}
