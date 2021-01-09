using Dapper;
using Domain.OxiServi.AggregatesModel.DistritoAggregate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.OxiServi.Repository
{
    public class DistritoRepository:IDistritoRepository
    {
        private string _connectionString = string.Empty;
        public DistritoRepository(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<int> CreateDistrito(Distrito Dis)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@nombre", Dis.nombre, DbType.String, ParameterDirection.Input);
                parameter.Add("@monto", Dis.monto, DbType.Double, ParameterDirection.Input);
                parameter.Add("@Result", Dis.result, direction: ParameterDirection.Output);
                var result = await cn.ExecuteScalarAsync<long>("SP_Create_Distrito", parameter, commandType: CommandType.StoredProcedure);
                var userId = parameter.Get<int>("@Result");
                return userId;
            }
        }

        public async Task<int> DeleteDistrito(Distrito Dis)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@idDistrito", Dis.idDistrito, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@result", DbType.Int32, direction: ParameterDirection.Output);
                var result = await cn.ExecuteScalarAsync<long>("[SP_DELETE_DISTRITO]", parameter, commandType: CommandType.StoredProcedure);
                var resultId = parameter.Get<int>("@result");
                return resultId;
            }
        }

        public async Task<int> DesactivateDistrito(Distrito Dis)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@idDistrito", Dis.idDistrito, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@result", DbType.Int32, direction: ParameterDirection.Output);
                var result = await cn.ExecuteScalarAsync<long>("[SP_DESACTIVAR_DISTRITO]", parameter, commandType: CommandType.StoredProcedure);
                var resultId = parameter.Get<int>("@result");
                return resultId;
            }
        }
    }
}
