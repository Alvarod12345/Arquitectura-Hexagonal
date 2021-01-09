using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Application.OxiServi.Queries.Auth
{
    public class AuthQueries : IAuthQueries
    {
        public string _connection;
        public AuthQueries(string connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<AuthViewModel>> GetUserById(int idUsuario)
        {
            using (var connection = new SqlConnection(_connection))
            {
                connection.Open();
                var parameter = new DynamicParameters();
                parameter.Add("@idUsuario", idUsuario, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                return await connection.QueryAsync<AuthViewModel>("SP_GET_CLIENTE_BY_ID", parameter, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
