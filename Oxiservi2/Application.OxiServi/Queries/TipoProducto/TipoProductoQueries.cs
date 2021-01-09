using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Application.OxiServi.Queries.TipoProducto
{
    public class TipoProductoQueries:ITipoProductoQueries
    {
        private string _connectionString = string.Empty;
        public TipoProductoQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }
        public async Task<TipoProductoPaginado> GetAllPagination(filterTipoProductoViewModel filter)
        {
            var model = new TipoProductoPaginado();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Page", filter.page, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameter.Add("@Rows", filter.rows, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameter.Add("@Total", System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);
                model.TipoProducto = await connection.QueryAsync<TipoProductoViewModel>(@"SP_GET_TIPO_PRODUCTO_PAGINADO", parameter, commandType: System.Data.CommandType.StoredProcedure);
                model.Total = parameter.Get<int>("@Total");
                return model;
            }
        }
    }
}
