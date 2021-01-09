using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Application.OxiServi.Queries.Maestro
{
    public class MaestroQueries : IMaestroQueries
    {
        public string _connectionString = string.Empty;
        public MaestroQueries(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<DetalleTipoProductoViewModel>> GetAllDetalleTipoProducto(int idTipoProducto)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@IdTipoProducto",idTipoProducto,DbType.Int32,ParameterDirection.Input);
                return await connection.QueryAsync<DetalleTipoProductoViewModel>(@"SP_GET_DETALLE_TIPO_PRODUCTO", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<DistritoViewModel>> GetAllDistrito()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return await connection.QueryAsync<DistritoViewModel>(@"SP_GET_ALL_DISTRITO", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<EstadoOrdenViewModel>> GetAllEstadoOrden()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return await connection.QueryAsync<EstadoOrdenViewModel>(@"SP_GET_ESTADO_ORDEN", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<EstadoProductoViewModel>> GetAllEstadosProducto()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return await connection.QueryAsync<EstadoProductoViewModel>(@"SP_GET_ESTADOS_PRODUCTO", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<RolViewModel>> GetAllRol()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return await connection.QueryAsync<RolViewModel>(@"SP_GET_ROL", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<TipoComprobanteViewModel>> GetAllTipoComprobante()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return await connection.QueryAsync<TipoComprobanteViewModel>(@"SP_GET_TIPO_COMPROBANTE", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<TipoDocuemntoViewModel>> GetAllTipoDocumento()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return await connection.QueryAsync<TipoDocuemntoViewModel>(@"SP_GET_TIPO_DOCUMENTO", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<TipoMovimientoViewModel>> GetAllTipoMovimiento()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return await connection.QueryAsync<TipoMovimientoViewModel>(@"SP_GET_TIPO_MOVIMIENTO", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<ImplementoViewModel>> GetImplemento()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return await connection.QueryAsync<ImplementoViewModel>(@"SP_GET_IMPLEMENTO", commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<ProveedorViewModel>> GetProveedorByTipoProducto(int tipo)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                DynamicParameters parameter= new DynamicParameters();
                parameter.Add("@idTipo", tipo, DbType.Int32, ParameterDirection.Input);
                return await connection.QueryAsync<ProveedorViewModel>(@"SP_GET_PROVEEDOR_BY_TIPO", parameter ,commandType: CommandType.StoredProcedure);
            }
        }
    }
}
