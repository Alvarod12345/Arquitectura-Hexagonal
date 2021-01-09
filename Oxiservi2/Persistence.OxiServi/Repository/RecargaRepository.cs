using Dapper;
using Domain.OxiServi.AggregatesModel.RecargaAggregate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Persistence.OxiServi.Repository
{
    public class RecargaRepository : IRecargaRepository
    {
        public string _connectionString = string.Empty;
        public RecargaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> AtenderRecarga(int idRecarga)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@idRecarga", idRecarga, DbType.Int32, ParameterDirection.Input);
                var result = await cn.ExecuteScalarAsync<long>("[SP_Atender_Recarga]", parameter, commandType: CommandType.StoredProcedure);
                return idRecarga;
            }
        }

        public async Task<int> Create(XElement xml)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@PRODUCTOXML", xml.ToString(), DbType.Xml, ParameterDirection.Input);
                parameter.Add("@ResultId", DbType.Int64, direction: ParameterDirection.Output);
                var result = await cn.ExecuteScalarAsync<long>("[SP_Create_Recarga]", parameter, commandType: CommandType.StoredProcedure);
                var userId = parameter.Get<int>("@ResultId");
                return userId;
            }
        }
        public async Task<int> GenerarRecarga(int idRecarga, int idProveedor,XElement recarga)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@idRecarga", idRecarga, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@idProveedor", idProveedor, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@PRODUCTOXML", recarga.ToString(), DbType.Xml, ParameterDirection.Input);
                parameter.Add("@ResultId", DbType.Int32, direction: ParameterDirection.Output);
                var result = await cn.ExecuteScalarAsync<long>("[SP_Create_Recarga]", parameter, commandType: CommandType.StoredProcedure);
                var userId = parameter.Get<int>("@ResultId");
                return userId;
            }
        }
        public async Task<int> DeleteProductoRecarga(int idRecarga, int idProducto)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@RecargaId", idRecarga, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@ProductoId", idProducto, DbType.Int32, ParameterDirection.Input);
                var result = await cn.ExecuteScalarAsync<long>("[SP_Delete_Producto_Recarga]", parameter, commandType: CommandType.StoredProcedure);
                return idRecarga;
            }
        }
    }
}
