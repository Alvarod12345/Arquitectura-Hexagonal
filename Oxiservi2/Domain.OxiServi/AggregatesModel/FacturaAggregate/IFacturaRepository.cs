using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Domain.OxiServi.AggregatesModel.FacturaAggregate
{
    public interface IFacturaRepository
    {
        Task<int> UpdateEstado(Factura factura);
    }
}
