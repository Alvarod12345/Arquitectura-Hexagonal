using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.OxiServi.Queries.Maestro
{
    public interface IMaestroQueries
    {
        Task<IEnumerable<EstadoOrdenViewModel>> GetAllEstadoOrden();
        Task<IEnumerable<TipoMovimientoViewModel>> GetAllTipoMovimiento();
        Task<IEnumerable<RolViewModel>> GetAllRol();
        Task<IEnumerable<TipoDocuemntoViewModel>> GetAllTipoDocumento();
        Task<IEnumerable<ImplementoViewModel>> GetImplemento();
        Task<IEnumerable<DistritoViewModel>> GetAllDistrito();
        Task<IEnumerable<DetalleTipoProductoViewModel>> GetAllDetalleTipoProducto(int idTipoProducto);
        Task<IEnumerable<ProveedorViewModel>> GetProveedorByTipoProducto(int idTipoProducto);
        Task<IEnumerable<EstadoProductoViewModel>> GetAllEstadosProducto(); 
        Task<IEnumerable<TipoComprobanteViewModel>> GetAllTipoComprobante(); 
    }
}
