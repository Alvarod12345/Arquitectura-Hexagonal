using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace Application.OxiServi.Queries.Factura
{
    public class FacturaQueries : IFacturaQueries
    {
        private string _connectionString = string.Empty;
        public FacturaQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }
        public async Task<IEnumerable<FacturaViewModel>> GetAll()
        {
            IEnumerable<FacturaViewModel> result;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                DynamicParameters parameter = new DynamicParameters();
                result = await connection.QueryAsync<FacturaViewModel>(@"SP_GET_ALL_FACTURA", parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<FacturaPaginado> GetAllPaginado(ListarFacturaViewModel listarParameter)
        {
            var model = new FacturaPaginado();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Page", listarParameter.page, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameter.Add("@Rows", listarParameter.rows, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameter.Add("@Total", System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);
                model.factura = await connection.QueryAsync<FacturaPaginadoViewModel>(@"SP_GET_FACTURA_PAGINADO", parameter, commandType: System.Data.CommandType.StoredProcedure);
                model.Total = parameter.Get<int>("@Total");
                return model;
            }
        }
    }
}
