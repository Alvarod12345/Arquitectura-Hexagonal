using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Application.OxiServi.Queries.User
{
    public class UserQueries : IUserQueries
    {
        private string _connectionString = string.Empty;
        public UserQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }
        public async Task<IEnumerable<UserViewModel>> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                DynamicParameters parameter = new DynamicParameters();
                var result = await connection.QueryAsync<UserViewModel>(@"SP_GET_LISTAUSUARIOS", parameter, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<IEnumerable<UserViewModel>> GetUsuarioById(ListarUsuarioByIdParameter idParameter)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@idUsuario", idParameter.idUsuario, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                var result = await connection.QueryAsync<UserViewModel>(@"SP_GET_USUARIO_BY_ID", parameter, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<IEnumerable<UserViewModel>> GetUsuarioByName(ListarUsuarioByNameParameter nameParameter)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@nombre", nameParameter.nombre, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                var result = await connection.QueryAsync<UserViewModel>(@"SP_GET_USUARIO_BY_ID", parameter, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<UsuarioPaginado> GetAllPaginado(ListarPaginadoParameters nameParameter)
        {
            var model = new UsuarioPaginado();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@page", nameParameter.page, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameter.Add("@rows", nameParameter.rows, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameter.Add("@idRol", nameParameter.idRol, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameter.Add("@tipDoc", nameParameter.tipDoc, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameter.Add("@numDoc", nameParameter.numDoc, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameter.Add("@Total",  System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);
                model.users = await connection.QueryAsync<UserViewModel>(@"SP_GET_USUARIOS_PAGINADO", parameter, commandType: System.Data.CommandType.StoredProcedure);
                model.Total = parameter.Get<int>("@Total");
                return model;
            }
        }
    }
}
