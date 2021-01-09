using Dapper;
using Domain.OxiServi.AggregatesModel.TipoProductoAggregate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.OxiServi.Repository
{
    public class TipoProductoRepository:ITipoProductoRepository
    {
        private string _connectionString = string.Empty;
        public TipoProductoRepository(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }
        public async Task<int> CreateTipoProducto(TipoProducto Tip)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@nombre", Tip.Nombre, DbType.String, ParameterDirection.Input);
                parameter.Add("@resultid", Tip.result, direction: ParameterDirection.Output);
                var result = await cn.ExecuteScalarAsync<long>("SP_Create_TipoProducto", parameter, commandType: CommandType.StoredProcedure);
                var userId = parameter.Get<int>("@resultid");
                return userId;
            }
        }
        public async Task<int> DesactivateTipoProducto(TipoProducto Tip)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@idTipoproducto", Tip.idTipoProducto, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@result", DbType.Int32, direction: ParameterDirection.Output);
                var result = await cn.ExecuteScalarAsync<long>("[SP_DESACTIVAR_TIPO_PRODUCTO]", parameter, commandType: CommandType.StoredProcedure);
                var resultId = parameter.Get<int>("@result");
                return resultId;
            }
        }
        public async Task<int> DeleteTipoProducto(TipoProducto Tip)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@idTipoproducto", Tip.idTipoProducto, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@result", DbType.Int32, direction: ParameterDirection.Output);
                var result = await cn.ExecuteScalarAsync<long>("[SP_DELETE_TIPO_PRODUCTO]", parameter, commandType: CommandType.StoredProcedure);
                var resultId = parameter.Get<int>("@result");
                return resultId;
            }
        }
    }
}
