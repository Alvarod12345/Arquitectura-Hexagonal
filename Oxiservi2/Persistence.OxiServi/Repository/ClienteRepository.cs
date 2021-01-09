using Dapper;
using Domain.OxiServi.AggregatesModel.ClienteAggregate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.OxiServi.Repository
{
    public class ClienteRepository : IClienteRespository
    {
        private string _connectionString = string.Empty;
        public ClienteRepository(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<int> CreateCliente(Cliente cli)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@numDocumento", cli.numDocumento, DbType.String, ParameterDirection.Input);
                parameter.Add("@tipoDocumento", cli.tipoDocumento, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@nombre", cli.nombre, DbType.String, ParameterDirection.Input);
                parameter.Add("@materno", cli.materno ,DbType.String, ParameterDirection.Input);
                parameter.Add("@paterno", cli.paterno, DbType.String, ParameterDirection.Input);
                parameter.Add("@telefono", cli.telefono, DbType.String, ParameterDirection.Input);
                parameter.Add("@correoElectronico", cli.correoElectronico, DbType.String, ParameterDirection.Input);
                parameter.Add("@resultId", DbType.Int32, direction: ParameterDirection.Output);
                var result = await cn.ExecuteScalarAsync<long>("SP_Create_Cliente_Persona", parameter, commandType: CommandType.StoredProcedure);
                var userId = parameter.Get<int>("@resultId");
                return userId;
            }
        }

        public async Task<int> CreateEmpresa(Cliente cli)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@numDocumento", cli.numDocumento, DbType.String, ParameterDirection.Input);
                parameter.Add("@tipoDocumento", cli.tipoDocumento, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@razonSocial", cli.razonSocial, DbType.String, ParameterDirection.Input);
                parameter.Add("@nombreContacto", cli.nombreContacto, DbType.String, ParameterDirection.Input);
                parameter.Add("@paternoContacto", cli.paternoContacto, DbType.String, ParameterDirection.Input);
                parameter.Add("@maternoContacto", cli.maternoContacto, DbType.String, ParameterDirection.Input);
                parameter.Add("@numDocumentoContacto", cli.numDocumentoContacto, DbType.String, ParameterDirection.Input);
                parameter.Add("@tipoDocumentoContacto", cli.tipoDocumentoContacto, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@telefono", cli.telefono, DbType.String, ParameterDirection.Input);
                parameter.Add("@correoElectronico", cli.correoElectronico, DbType.String, ParameterDirection.Input);
                parameter.Add("@resultId", DbType.Int32, direction: ParameterDirection.Output);
                var result = await cn.ExecuteScalarAsync<long>("SP_Create_Cliente_Empresa", parameter, commandType: CommandType.StoredProcedure);
                var userId = parameter.Get<int>("@resultId");
                return userId;
            }
        }

        public async Task<int> UpdateCliente(Cliente cli)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@IdCliente", cli.idCliente, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@numDocumento", cli.numDocumento, DbType.String, ParameterDirection.Input);
                parameter.Add("@tipoDocumento", cli.tipoDocumento, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@nombre", cli.nombre, DbType.String, ParameterDirection.Input);
                parameter.Add("@materno", cli.materno, DbType.String, ParameterDirection.Input);
                parameter.Add("@paterno", cli.paterno, DbType.String, ParameterDirection.Input);
                parameter.Add("@telefono", cli.telefono, DbType.String, ParameterDirection.Input);
                parameter.Add("@correoElectronico", cli.correoElectronico, DbType.String, ParameterDirection.Input);
                parameter.Add("@resultId", DbType.Int32, direction: ParameterDirection.Output);
                var result = await cn.ExecuteScalarAsync<long>("[SP_Update_Cliente_Persona]", parameter, commandType: CommandType.StoredProcedure);
                var userId = parameter.Get<int>("@resultId");
                return userId;
            }
        }

        public async Task<int> UpdateEmpresa(Cliente cli)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@IdCliente", cli.idCliente, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@numDocumento", cli.numDocumento, DbType.String, ParameterDirection.Input);
                parameter.Add("@tipoDocumento", cli.tipoDocumento, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@razonSocial", cli.razonSocial, DbType.String, ParameterDirection.Input);
                parameter.Add("@nombreContacto", cli.nombreContacto, DbType.String, ParameterDirection.Input);
                parameter.Add("@paternoContacto", cli.paternoContacto, DbType.String, ParameterDirection.Input);
                parameter.Add("@maternoContacto", cli.maternoContacto, DbType.String, ParameterDirection.Input);
                parameter.Add("@numDocumentoContacto", cli.numDocumentoContacto, DbType.String, ParameterDirection.Input);
                parameter.Add("@tipoDocumentoContacto", cli.tipoDocumentoContacto, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@telefono", cli.telefono, DbType.String, ParameterDirection.Input);
                parameter.Add("@correoElectronico", cli.correoElectronico, DbType.String, ParameterDirection.Input);
                parameter.Add("@resultId", DbType.Int32, direction: ParameterDirection.Output);
                var result = await cn.ExecuteScalarAsync<long>("[SP_Update_Cliente_Empresa]", parameter, commandType: CommandType.StoredProcedure);
                var userId = parameter.Get<int>("@resultId");
                return userId;
            }
        }
    }
}
