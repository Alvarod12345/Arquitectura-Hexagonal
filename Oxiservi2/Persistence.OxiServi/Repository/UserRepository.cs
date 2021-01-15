using System.Threading.Tasks;
using System.Data.SqlClient;
using Domain.OxiServi.AggregatesModel.UserAggregate;
using System;
using Dapper;
using System.Data;

namespace Persistence.OxiServi.Repository
{
    public class UserRepository : IUserRepository
    {
        private string _connectionString = string.Empty;
        public UserRepository(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }
        public async Task<int> Create(User user)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@nombre",user.nombre,DbType.String,ParameterDirection.Input);
                parameter.Add("@paterno", user.paterno, DbType.String, ParameterDirection.Input);
                parameter.Add("@materno", user.materno, DbType.String, ParameterDirection.Input);
                parameter.Add("@numDocumento", user.numDocumento, DbType.String, ParameterDirection.Input);
                parameter.Add("@pass", user.contrasena, DbType.String, ParameterDirection.Input);
                parameter.Add("@email", user.email, DbType.String, ParameterDirection.Input);
                parameter.Add("@phone", user.telefono, DbType.String, ParameterDirection.Input);
                parameter.Add("@msj", DbType.Int32, direction: ParameterDirection.Output);
                var result = await cn.ExecuteScalarAsync<long>("[SP_Insert_User]", parameter, commandType: CommandType.StoredProcedure);
                var userId = parameter.Get<int>("@resultId");
                return userId;
            }
        }
        public async Task<int> Update(User user)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@idUsuario", user.idUsuario, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@nombre", user.nombre, DbType.String, ParameterDirection.Input);
                parameter.Add("@paterno", user.paterno, DbType.String, ParameterDirection.Input);
                parameter.Add("@materno", user.materno, DbType.String, ParameterDirection.Input);
                parameter.Add("@numDocumento", user.numDocumento, DbType.String, ParameterDirection.Input);
                parameter.Add("@pass", user.contrasena, DbType.String, ParameterDirection.Input);
                parameter.Add("@email", user.email, DbType.String, ParameterDirection.Input);
                parameter.Add("@phone", user.telefono, DbType.String, ParameterDirection.Input);
                parameter.Add("@msj", DbType.Int32, direction: ParameterDirection.Output);
                var result = await cn.ExecuteScalarAsync<long>("[SP_Update_User]", parameter, commandType: CommandType.StoredProcedure);
                var userId = parameter.Get<int>("@resultid");
                return userId;
            }
        }
        public async Task<int> Delete(User user)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@idUsuario", user.idUsuario, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@msj", DbType.Int32, direction: ParameterDirection.Output);

                var result = await cn.ExecuteScalarAsync<long>("[SP_Delete_User]", parameter, commandType: CommandType.StoredProcedure);
                var msj = parameter.Get<int>("@msj");
                return msj;
            }
        }
    }
}
