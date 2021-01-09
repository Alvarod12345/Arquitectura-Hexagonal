using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Application.OxiServi.Queries.Implemento
{
    public class ImplementoQueries:IImplementoQueries
    {
        private string _connectionString = string.Empty;
        public ImplementoQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }
        public async Task<ImplementoPaginado> GetAllPagination(filterImplementoViewModel filter)
        {
            var model = new ImplementoPaginado();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Page", filter.page, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameter.Add("@Rows", filter.rows, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameter.Add("@Total", System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);
                model.Implemento = await connection.QueryAsync<ImplementoViewModel>(@"SP_GET_IMPLEMENTO_PAGINADO", parameter, commandType: System.Data.CommandType.StoredProcedure);
                model.Total = parameter.Get<int>("@Total");
                return model;
            }
        }
    }
}
