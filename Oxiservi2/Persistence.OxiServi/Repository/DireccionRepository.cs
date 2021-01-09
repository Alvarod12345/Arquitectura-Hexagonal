using Dapper;
using Domain.OxiServi.AggregatesModel.DireccionAggregate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.OxiServi.Repository
{
    public class DireccionRepository : IDireccionRepository
    {
        private string _connectionString = string.Empty;

        public DireccionRepository(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }
        public async Task<int> Create(Direccion direccion)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@idDistrito", direccion.IdDistrito, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@idCliente", direccion.IdCliente, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@lote", direccion.Lote, DbType.String, ParameterDirection.Input);
                parameter.Add("@urbanizacion", direccion.Urbanizacion, DbType.String, ParameterDirection.Input);
                parameter.Add("@referencia", direccion.Referencia, DbType.String, ParameterDirection.Input);
                parameter.Add("@Descripcion", direccion.Descripcion, DbType.String, ParameterDirection.Input);
                parameter.Add("@Latitud", direccion.Latitud, DbType.Decimal, ParameterDirection.Input);
                parameter.Add("@Longitud", direccion.Longitud, DbType.Decimal, ParameterDirection.Input);
                parameter.Add("@idDireccion", DbType.Int32, direction: ParameterDirection.Output);
                var result = await cn.ExecuteScalarAsync("SP_CREATE_DIRECCION", parameter, commandType: CommandType.StoredProcedure);
                var direccionId = parameter.Get<int>("@idDireccion");
                return direccionId;
            }
        }
        public async Task<int> Active(Direccion direccion)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@idDireccion", direccion.IdDireccion, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result = await cn.ExecuteScalarAsync("SP_ACTIVE_DIRECCION", parameter, commandType: CommandType.StoredProcedure);
                var resultId = parameter.Get<int>("@Result");
                return resultId;
            }
        }
        public async Task<int> Delete(Direccion direccion)
        {
            using(var cn=new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@idDireccion", direccion.IdDireccion, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result = await cn.ExecuteScalarAsync("SP_DELETE_DIRECCION", parameter, commandType: CommandType.StoredProcedure);
                var resultId = parameter.Get<int>("@Result");
                return resultId;
            }
        }
    }
}
