using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.OxiServi.AggregatesModel.ProductoAggregate
{
    public interface IProductoRepository
    {
        Task<int> Create(Producto producto);
        Task<int> Update(Producto producto);
        Task<bool> ValidateSerie(string serie);
        Task<bool> DesactivarProducto(Producto producto);
    }
}
