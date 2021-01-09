using Dapper;
using Domain.OxiServi.AggregatesModel.OrdenAggregate;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Persistence.OxiServi.Repository
{
    public class OrdenRepository : IOrdenRepository
    {
        public string _connectionString = string.Empty;
        public OrdenRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> CancelarOrden(int idOrden, DateTime today)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@IdOrden", idOrden, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@TodayDate", today, DbType.Date, ParameterDirection.Input);
                parameter.Add("@ResultId", DbType.Int32, direction: ParameterDirection.Output);
                var result = await cn.ExecuteScalarAsync<long>("SP_CANCELAR_ORDEN", parameter, commandType: CommandType.StoredProcedure);
                var userId = parameter.Get<int>("@ResultId");
                return userId;
            }
        }

        public async Task<int> UpdateEstado(Orden orden,DateTime dateTime)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@IdOrden", orden.idOrden, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@IdEstadoOrden", orden.idEstadoOrden, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@fecha", dateTime, DbType.DateTime, ParameterDirection.Input);
                parameter.Add("@ResultId", DbType.Int32, direction: ParameterDirection.Output);
                var result = await cn.ExecuteScalarAsync<long>("SP_UPDATE_ESTADO_ORDEN", parameter, commandType: CommandType.StoredProcedure);
                var userId = parameter.Get<int>("@ResultId");
                return userId;
            }
        }
    }
}
