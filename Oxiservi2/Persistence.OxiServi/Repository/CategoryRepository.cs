using Dapper;
using Domain.OxiServi.AggregatesModel.CategoryAggregate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Northwind.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private string _connectionString = string.Empty;
        public CategoryRepository(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<int> Create(Category category)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@CategoryName", category.CategoryName, DbType.String, ParameterDirection.Input);
                parameter.Add("@Description", category.Description, DbType.String, ParameterDirection.Input);
                parameter.Add("@msj", DbType.Int32, direction: ParameterDirection.Output);

                var result = await cn.ExecuteScalarAsync<long>("[SP_Insert_Category]", parameter, commandType: CommandType.StoredProcedure);
                var msj = parameter.Get<int>("@msj");
                return msj;
            }
        }

        public async Task<int> Delete(Category category)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@CategoryID", category.CategoryID, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@msj", DbType.Int32, direction: ParameterDirection.Output);

                var result = await cn.ExecuteScalarAsync<long>("[SP_Delete_Category]", parameter, commandType: CommandType.StoredProcedure);
                var msj = parameter.Get<int>("@msj");
                return msj;
            }
        }

        public async Task<int> Update(Category category)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@CategoryID", category.CategoryID, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@CategoryName", category.CategoryName, DbType.String, ParameterDirection.Input);
                parameter.Add("@Description", category.Description, DbType.String, ParameterDirection.Input);
                parameter.Add("@msj", DbType.Int32, direction: ParameterDirection.Output);

                var result = await cn.ExecuteScalarAsync<long>("[SP_Update_Category]", parameter, commandType: CommandType.StoredProcedure);
                var msj = parameter.Get<int>("@msj");
                return msj;
            }
        }
    }
}
