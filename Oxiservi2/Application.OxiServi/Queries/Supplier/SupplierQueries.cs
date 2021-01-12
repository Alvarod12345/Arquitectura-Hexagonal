using Application.OxiServi.Queries.Base;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace Application.OxiServi.Queries.Supplier
{
    public class SupplierQueries : ISupplierQueries
    {
        private string _connectionString = string.Empty;
        public SupplierQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }
        public async Task<IEnumerable<SupplierViewModel>> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                DynamicParameters parameter = new DynamicParameters();
                return await connection.QueryAsync<SupplierViewModel>(@"[SP_Select_Supplier]", parameter, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
