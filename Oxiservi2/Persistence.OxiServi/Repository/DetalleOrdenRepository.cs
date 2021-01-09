using Dapper;
using Domain.OxiServi.AggregatesModel.DetalleOrdenAggregate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Persistence.OxiServi.Repository
{
    public class DetalleOrdenRepository : IDetalleOrdenRepository
    {
        private string _connectionString = string.Empty;
        public DetalleOrdenRepository(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }
        public async Task<int> Update(DetalleOrden detO)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@iddeorden", detO.idDetalleOrden, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@comentario", detO.comentario, DbType.String, ParameterDirection.Input);
                parameter.Add("@result", detO.result, direction: ParameterDirection.Output);
                var result = await cn.ExecuteScalarAsync<long>("SP_DEVOLUCION_DETALLE_ORDEN", parameter, commandType: CommandType.StoredProcedure);
                var userId = parameter.Get<int>("@result");
                return userId;
            }
        }
        public async Task<int> UpdateDetalleOrden(DetalleOrden detalleOrden)
        {
            using (var cn=new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@idDetalleOrden", detalleOrden.idDetalleOrden, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@idEstadoDetalleOrden", detalleOrden.idEstadoOrden, DbType.Int32, ParameterDirection.Input);
                //parameter.Add("@XMLidDetalleOrden",xElement.ToString(),DbType.Xml,ParameterDirection.Input);
                parameter.Add("@result",DbType.Int32,direction:ParameterDirection.Output);
                var result = await cn.ExecuteScalarAsync<long>("SP_UPDATE_DETALLE_ORDEN", parameter, commandType: CommandType.StoredProcedure);
                var userId = parameter.Get<int>("@result");
                return userId;
            }
        }
        public async Task<int> DevolverProducto(DetalleOrden detO)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@idDetalleOrden", detO.idDetalleOrden, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@isDañado", detO.isDañado, DbType.Boolean, ParameterDirection.Input);
                parameter.Add("@comentario", detO.comentario, DbType.String, ParameterDirection.Input);
                parameter.Add("@resultId", DbType.Boolean, direction: ParameterDirection.Output);
                await cn.ExecuteScalarAsync<long>("SP_DEVOLVER_PRODUCTO", parameter, commandType: CommandType.StoredProcedure);
                var result = parameter.Get<int>("@resultId");
                return result;
            }
        }
    }
}
