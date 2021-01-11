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
                parameter.Add("@NombreCompany", supplier.CompanyName, DbType.String, ParameterDirection.Input);
                parameter.Add("@NombreContacto", supplier.ContactName, DbType.String, ParameterDirection.Input);
                parameter.Add("@TituloContacto", supplier.ContactTitle, DbType.String, ParameterDirection.Input);
                parameter.Add("@Direccion", supplier.Address, DbType.String, ParameterDirection.Input);
                parameter.Add("@Ciudad", supplier.City, DbType.String, ParameterDirection.Input);
                parameter.Add("@CodPostal", supplier.PostalCode, DbType.String, ParameterDirection.Input);
                parameter.Add("@Pais", supplier.Country, DbType.String, ParameterDirection.Input);
                parameter.Add("@Telefono", supplier.Phone, DbType.String, ParameterDirection.Input);
                parameter.Add("@msj", DbType.Int32, direction: ParameterDirection.Output);

                var result = await cn.ExecuteScalarAsync<long>("[SP_Insertar_Proveedor]", parameter, commandType: CommandType.StoredProcedure);
                var msj = parameter.Get<int>("@msj");
                return msj;
            }
        }

        public Task<int> Update(Supplier supplier)
        {
            throw new NotImplementedException();
        }
    }
}
