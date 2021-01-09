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
                parameter.Add("@tipoDocumento", user.tipoDocumento, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@telefono", user.telefono, DbType.String, ParameterDirection.Input);
                parameter.Add("@email", user.email, DbType.String, ParameterDirection.Input);
                parameter.Add("@contraseña", user.contrasena, DbType.String, ParameterDirection.Input);
                parameter.Add("@idRol", user.idRol, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@resultId", DbType.Int64, direction: ParameterDirection.Output);
                var result = await cn.ExecuteScalarAsync<long>("[SP_Create_Usuario]", parameter, commandType: CommandType.StoredProcedure);
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
                parameter.Add("@tipoDocumento", user.tipoDocumento, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@telefono", user.telefono, DbType.String, ParameterDirection.Input);
                parameter.Add("@email", user.email, DbType.String, ParameterDirection.Input);
                parameter.Add("@contraseña", user.contrasena, DbType.String, ParameterDirection.Input);
                parameter.Add("@idRol", user.idRol, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@resultid",DbType.Int32,direction : ParameterDirection.Output);
                var result = await cn.ExecuteScalarAsync<long>("[SP_UPDATE_USUARIO]", parameter, commandType: CommandType.StoredProcedure);
                var userId = parameter.Get<int>("@resultid");
                return userId;
            }
        }
        public async Task<int> Desactivar(User user)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@idUsuario", user.idUsuario, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@resultid", DbType.Int32, direction: ParameterDirection.Output);
                var result = await cn.ExecuteScalarAsync<long>("[SP_DESACTIVAR_USUARIO]", parameter, commandType: CommandType.StoredProcedure);
                var userId = parameter.Get<int>("@resultid");
                return userId;
            }
        }
        public async Task<bool> ValidateDocumento(int tipoDocumento, string numDocumento)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@TipoDocumentoId", tipoDocumento, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@NumDocumento", numDocumento, DbType.String, ParameterDirection.Input);
                parameter.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                await cn.ExecuteScalarAsync<long>("SP_Validate_Documento", parameter, commandType: CommandType.StoredProcedure);
                var result = parameter.Get<int>("@Result");
                if (result == 0)
                    return false;
                else
                    return true;
            }
        }
    }
}
