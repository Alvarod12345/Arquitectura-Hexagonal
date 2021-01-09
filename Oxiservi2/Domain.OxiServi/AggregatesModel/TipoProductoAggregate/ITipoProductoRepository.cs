using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.OxiServi.AggregatesModel.TipoProductoAggregate
{
    public interface ITipoProductoRepository
    {
        Task<int> CreateTipoProducto(TipoProducto tipoProducto);
        Task<int> DesactivateTipoProducto(TipoProducto tipoProducto);
        Task<int> DeleteTipoProducto(TipoProducto tipoProducto);
    }
}
