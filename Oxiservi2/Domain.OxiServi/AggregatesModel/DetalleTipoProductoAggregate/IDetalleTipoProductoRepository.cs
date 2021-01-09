using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.OxiServi.AggregatesModel.DetalleTipoProductoAggregate
{
    public interface IDetalleTipoProductoRepository
    {
        Task<int> CreateDetalleTipoProducto(DetalleTipoProducto detalleTipoProducto);
        Task<int> DesactivarDetalleTipoProducto(DetalleTipoProducto detalleTipoProducto);
        Task<int> DeleteDetalleTipoProducto(DetalleTipoProducto detalleTipoProducto);
    }
}
