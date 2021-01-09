using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Application.OxiServi.Queries.Direccion
{
    public class DireccionQueries : IDireccionQueries
    {
        public string _connectionStirng;
        public DireccionQueries(string connectionString)
        {
            _connectionStirng = connectionString;
        }

        public async Task<IEnumerable<DireccionViewModel>> GetAll()
        {
            using (var connection = new SqlConnection(_connectionStirng))
            {
                connection.Open();
                return await connection.QueryAsync<DireccionViewModel>(@"[SP_GET_DIRECCION]", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<DireccionViewModel>> GetAllByCliente(int idCliente)
        {
            using (var connection = new SqlConnection(_connectionStirng))
            {
                connection.Open();
                var parameter = new DynamicParameters();
                parameter.Add("@idCliente", idCliente, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                return await connection.QueryAsync<DireccionViewModel>(@"[SP_GET_DIRECCION_BY_CLIENTE]", parameter, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
