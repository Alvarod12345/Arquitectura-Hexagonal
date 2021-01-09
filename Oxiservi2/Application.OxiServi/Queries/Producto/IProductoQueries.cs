using Application.OxiServi.Queries.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.OxiServi.Queries.Producto
{
    public interface IProductoQueries
    {
        Task<IEnumerable<ProductoViewModel>> GetAll();
        Task<ProductoViewModel> GetAllById(ListarProductoByIdParametro pr);
        Task<IEnumerable<ListarTipoProductoViewModel>> GetTipoProducto();
        Task<ListarProductoViewModel> GetAllPaginado(ListarFiltroProductoViewModel filter);
        Task<IEnumerable<ProductoViewModel>> GetAutocomplete(string query);
        Task<IEnumerable<ListarProductoRecarga>> GetProductoRecarga(string serie);
    }
}
