using System;
using Domain.OxiServi.AggregatesModel.SuppliersAggregate;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace Persistence.OxiServi.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        private string _connectionString = string.Empty;
        public SupplierRepository(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<int> Create(Supplier supplier)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@CompanyName", supplier.CompanyName, DbType.String, ParameterDirection.Input);
                parameter.Add("@ContactName", supplier.ContactName, DbType.String, ParameterDirection.Input);
                parameter.Add("@ContactTitle", supplier.ContactTitle, DbType.String, ParameterDirection.Input);
                parameter.Add("@Address", supplier.Address, DbType.String, ParameterDirection.Input);
                parameter.Add("@City", supplier.City, DbType.String, ParameterDirection.Input);
                parameter.Add("@Region", supplier.PostalCode, DbType.String, ParameterDirection.Input);
                parameter.Add("@PostalCode", supplier.PostalCode, DbType.String, ParameterDirection.Input);
                parameter.Add("@Country", supplier.Country, DbType.String, ParameterDirection.Input);
                parameter.Add("@Phone", supplier.Phone, DbType.String, ParameterDirection.Input);
                parameter.Add("@Fax", supplier.Fax, DbType.String, ParameterDirection.Input);
                parameter.Add("@HomePage", supplier.HomePage, DbType.String, ParameterDirection.Input);
                parameter.Add("@msj", DbType.Int32, direction: ParameterDirection.Output);

                var result = await cn.ExecuteScalarAsync<long>("[SP_Insert_Supplier]", parameter, commandType: CommandType.StoredProcedure);
                var msj = parameter.Get<int>("@msj");
                return msj;
            }
        }

        public async Task<int> Update(Supplier supplier)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@SupplierId", supplier.SupplierId, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@CompanyName", supplier.CompanyName, DbType.String, ParameterDirection.Input);
                parameter.Add("@ContactName", supplier.ContactName, DbType.String, ParameterDirection.Input);
                parameter.Add("@ContactTitle", supplier.ContactTitle, DbType.String, ParameterDirection.Input);
                parameter.Add("@Address", supplier.Address, DbType.String, ParameterDirection.Input);
                parameter.Add("@City", supplier.City, DbType.String, ParameterDirection.Input);
                parameter.Add("@Region", supplier.PostalCode, DbType.String, ParameterDirection.Input);
                parameter.Add("@PostalCode", supplier.PostalCode, DbType.String, ParameterDirection.Input);
                parameter.Add("@Country", supplier.Country, DbType.String, ParameterDirection.Input);
                parameter.Add("@Phone", supplier.Phone, DbType.String, ParameterDirection.Input);
                parameter.Add("@Fax", supplier.Phone, DbType.String, ParameterDirection.Input);
                parameter.Add("@HomePage", supplier.Phone, DbType.String, ParameterDirection.Input);
                parameter.Add("@msj", DbType.Int32, direction: ParameterDirection.Output);

                var result = await cn.ExecuteScalarAsync<long>("[SP_Update_Supplier]", parameter, commandType: CommandType.StoredProcedure);
                var msj = parameter.Get<int>("@msj");
                return msj;
            }
        }

        public async Task<int> Delete(Supplier supplier)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@SupplierId", supplier.SupplierId, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@msj", DbType.Int32, direction: ParameterDirection.Output);

                var result = await cn.ExecuteScalarAsync<long>("[SP_Delete_Supplier]", parameter, commandType: CommandType.StoredProcedure);
                var msj = parameter.Get<int>("@msj");
                return msj;
            }
        }
    }
}
