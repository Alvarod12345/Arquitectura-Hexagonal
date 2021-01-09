using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Domain.OxiServi.AggregatesModel.CotizacionAggregate;
using Dapper;
using System.Xml.Linq;

namespace Persistence.OxiServi.Repository
{
    public class CotizacionRepository : ICotizacionRepository
    {
        private string _connectionString = string.Empty;

        public CotizacionRepository(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }
        public async Task<int> Create(Cotizacion cotizacion, XElement xmlproducto)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@idCliente", cotizacion.idCliente, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@Monto", cotizacion.Monto, DbType.Double, ParameterDirection.Input);
                parameter.Add("@idDireccion", cotizacion.idDireccion, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@XMLCotizacion", xmlproducto.ToString(), DbType.Xml, ParameterDirection.Input);
                parameter.Add("@resultId", DbType.Int32, direction: ParameterDirection.Output);
                var result = await cn.ExecuteScalarAsync<long>("SP_Create_Cotizacion", parameter, commandType: CommandType.StoredProcedure);
                var userId = parameter.Get<int>("@resultId");
                return userId;
            }
        }

        public async Task<int> GenerarOrden(Cotizacion cotizacion)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@CotizacionId", cotizacion.CotizacionId, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@FechaEntrega", cotizacion.FechaEntrega, DbType.Date, ParameterDirection.Input);
                parameter.Add("@RUC", cotizacion.RUC, DbType.String, ParameterDirection.Input);
                parameter.Add("@IdTipoComprobante", cotizacion.IdTipoComprobante, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@NumeroOrden", 123, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@ResultId", DbType.Int32, direction: ParameterDirection.Output);
                var result = await cn.ExecuteScalarAsync<long>("SP_Genear_Orden", parameter, commandType: CommandType.StoredProcedure);
                var userId = parameter.Get<int>("@ResultId");
                return userId;
            }
        }

        public async Task<string> GetLastNumeroOrden()
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var result = await cn.ExecuteScalarAsync<string>("GET_LAST_NUMERO_ORDEN", commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
