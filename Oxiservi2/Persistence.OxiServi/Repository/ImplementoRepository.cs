using Dapper;
using Domain.OxiServi.AggregatesModel.ImplementoAggregate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.OxiServi.Repository
{
    public class ImplementoRepository:IImplementoRepository
    {
        private string _connectionString = string.Empty;
        public ImplementoRepository(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }
        public async Task<int> CreateImplemento(Implemento Imp)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@descripcion", Imp.Descripcion, DbType.String, ParameterDirection.Input);
                parameter.Add("@precio", Imp.Precio, DbType.Double, ParameterDirection.Input);
                parameter.Add("@resultid", Imp.result, direction: ParameterDirection.Output);
                var result = await cn.ExecuteScalarAsync<long>("SP_Create_Implemento", parameter, commandType: CommandType.StoredProcedure);
                var userId = parameter.Get<int>("@resultid");
                return userId;
            }
        }
        public async Task<int> DesactivateImplemento(Implemento Imp)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@implementoId",Imp.ImplementoId, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@result", DbType.Int32, direction: ParameterDirection.Output);
                var result = await cn.ExecuteScalarAsync<long>("[SP_DESACTIVAR_IMPLEMENTO]", parameter, commandType: CommandType.StoredProcedure);
                var resultId = parameter.Get<int>("@result");
                return resultId;
            }
        }
        public async Task<int> DeleteImplemento(Implemento Imp)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@implementoId", Imp.ImplementoId, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@result", DbType.Int32, direction: ParameterDirection.Output);
                var result = await cn.ExecuteScalarAsync<long>("[SP_DELETE_IMPLEMENTO]", parameter, commandType: CommandType.StoredProcedure);
                var resultId = parameter.Get<int>("@result");
                return resultId;
            }
        }
    }
}
