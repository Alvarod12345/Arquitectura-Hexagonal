using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Application.Northwind.Queries.Category
{
    public class CategoryQueries : ICategoryQueries
    {
        private string _connectionString = string.Empty;
        public CategoryQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                DynamicParameters parameter = new DynamicParameters();
                return await connection.QueryAsync<CategoryViewModel>(@"[SP_Select_Category]", parameter, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
