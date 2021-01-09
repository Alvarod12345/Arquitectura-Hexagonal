using Dapper;
using Domain.OxiServi.AggregatesModel.FacturaAggregate;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Persistence.OxiServi.Repository
{
    public class FacturaRepository : IFacturaRepository
    {
        public string _connectionString = string.Empty;
        public FacturaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<int> UpdateEstado(Factura factura)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@IdComprobante", factura.IdComprobante, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@ResultId", DbType.Int32, direction: ParameterDirection.Output);
                var result = await cn.ExecuteScalarAsync<long>("SP_UPDATE_ESTADO_FACTURA", parameter, commandType: CommandType.StoredProcedure);
                var userId = parameter.Get<int>("@ResultId");
                return userId;
            }
        }
    }
}
