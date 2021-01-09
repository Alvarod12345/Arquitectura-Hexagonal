using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.OxiServi.AggregatesModel.DetalleOrdenAggregate
{
    public interface IDetalleOrdenRepository
    {
        Task<int> Update(DetalleOrden detalleOrden);
        Task<int> UpdateDetalleOrden(DetalleOrden detalleOrden);
        Task<int> DevolverProducto(DetalleOrden detalleOrden);
    }
}
