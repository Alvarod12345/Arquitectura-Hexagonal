using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.OxiServi.AggregatesModel.CotizacionAggregate
{
    public interface ICotizacionRepository
    { 
        Task<int> Create(Cotizacion cotizacion, XElement Xmlproducto);
        Task<int> GenerarOrden(Cotizacion cotizacion);
        Task<string> GetLastNumeroOrden();
    }
}
