using Dapper;
using Domain.Northwind.AggregatesModel.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Northwind.Repository
{
    public class ProductRepository : IProductRepository
    {
        private string _connectionString = string.Empty;
        public ProductRepository(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<int> Create(Product product)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@ProductName", product.ProductName, DbType.String, ParameterDirection.Input);
                parameter.Add("@SupplierID", product.SupplierID, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@CategoryID", product.CategoryID, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@QuantityPerUnit", product.QuantityPerUnit, DbType.String, ParameterDirection.Input);
                parameter.Add("@UnitPrice", product.UnitPrice, DbType.Double, ParameterDirection.Input);
                parameter.Add("@UnitsInStock", product.UnitsInStock, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@UnitsOnOrder", product.UnitsOnOrder, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@ReorderLevel", product.ReoderLevel, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@msj", DbType.Int32, direction: ParameterDirection.Output);

                var result = await cn.ExecuteScalarAsync<long>("[SP_Insert_Product]", parameter, commandType: CommandType.StoredProcedure);
                var msj = parameter.Get<int>("@msj");
                return msj;
            }
        }

        public async Task<int> Delete(Product product)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@ProductID", product.ProductID, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@msj", DbType.Int32, direction: ParameterDirection.Output);

                var result = await cn.ExecuteScalarAsync<long>("[SP_Delete_Product]", parameter, commandType: CommandType.StoredProcedure);
                var msj = parameter.Get<int>("@msj");
                return msj;
            }
        }

        public async Task<int> Update(Product product)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@ProductID", product.ProductID, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@ProductName", product.ProductName, DbType.String, ParameterDirection.Input);
                parameter.Add("@SupplierID", product.SupplierID, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@CategoryID", product.CategoryID, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@QuantityPerUnit", product.QuantityPerUnit, DbType.String, ParameterDirection.Input);
                parameter.Add("@UnitPrice", product.UnitPrice, DbType.Double, ParameterDirection.Input);
                parameter.Add("@UnitsInStock", product.UnitsInStock, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@UnitsOnOrder", product.UnitsOnOrder, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@ReorderLevel", product.ReoderLevel, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@Discontinued", product.Discontinued, DbType.Boolean, ParameterDirection.Input);
                parameter.Add("@msj", DbType.Int32, direction: ParameterDirection.Output);

                var result = await cn.ExecuteScalarAsync<long>("[SP_Update_Product]", parameter, commandType: CommandType.StoredProcedure);
                var msj = parameter.Get<int>("@msj");
                return msj;
            }
        }
    }
}
