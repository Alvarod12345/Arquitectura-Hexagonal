using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Application.Northwind.Queries.Product
{
    public class ProductQueries : IProductQueries
    {
        private string _connectionString = string.Empty;
        public ProductQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                DynamicParameters parameter = new DynamicParameters();
                return await connection.QueryAsync<ProductViewModel>(@"[SP_Select_Product]", parameter, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
