using Dapper;
using Domain.OxiServi.AggregatesModel.AuthAggregate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.OxiServi.Repository
{
    public class UserLoginRepository : IUserLoginRepository
    {
        public string _connectionstring;
        public UserLoginRepository(string connectionstring)
        {
            _connectionstring = connectionstring;
        }
        public async Task<int> Login(UserLogin userLogin)
        {
            using(var connection= new SqlConnection(_connectionstring))
            {
                connection.Open();
                var parameter = new DynamicParameters();
                parameter.Add("@email",userLogin.Email,System.Data.DbType.String,System.Data.ParameterDirection.Input);
                parameter.Add("@password",userLogin.Password,System.Data.DbType.String,System.Data.ParameterDirection.Input);
                parameter.Add("@resultid",System.Data.DbType.Int32,direction:System.Data.ParameterDirection.Output);
                var result =  await connection.ExecuteScalarAsync("SP_Validar_Usuario", parameter,commandType : CommandType.StoredProcedure);
                var resultid = parameter.Get<int>("@resultid");
                return resultid;
            }
        }
    }
}
