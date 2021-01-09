using Dapper;
using Domain.OxiServi.AggregatesModel.DetalleTipoProductoAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Persistence.OxiServi.Repository
{
    public class DetalleTipoProductoRepository: IDetalleTipoProductoRepository
    {
        private string _connectionString = string.Empty;
        public DetalleTipoProductoRepository(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<int> CreateDetalleTipoProducto(DetalleTipoProducto detP)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@descripcion", detP.descripcion, DbType.String, ParameterDirection.Input);
                parameter.Add("@idTipoproducto", detP.idTipoProducto, DbType.Int64, ParameterDirection.Input);
                parameter.Add("@result", detP.result, direction: ParameterDirection.Output);
                var result = await cn.ExecuteScalarAsync<long>("SP_Create_Detalle_TipoProducto", parameter, commandType: CommandType.StoredProcedure);
                var userId = parameter.Get<int>("@result");
                return userId;
            }
        }

        public async Task<int> DesactivarDetalleTipoProducto(DetalleTipoProducto detP)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@idDetalleTipo", detP.idTipoProducto, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@resultid", DbType.Int32, direction: ParameterDirection.Output);
                var result = await cn.ExecuteScalarAsync<long>("[SP_DESACTIVAR_DETALLE_TIPO_PRODUCTO]", parameter, commandType: CommandType.StoredProcedure);
                var detalletipoId = parameter.Get<int>("@resultid");
                return detalletipoId;
            }
        }

        public async Task<int> DeleteDetalleTipoProducto(DetalleTipoProducto detP)
        {
            using (var cn=new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@idDetalle", detP.idTipoProducto, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@resultid", DbType.Int32, direction: ParameterDirection.Output);
                var result = await cn.ExecuteScalarAsync<long>("[SP_DELETE_DETALLE_TIPO_PRODUCTO]", parameter, commandType: CommandType.StoredProcedure);
                var detalletipoId = parameter.Get<int>("@resultid");
                return detalletipoId;
            }
        }
    }
}
