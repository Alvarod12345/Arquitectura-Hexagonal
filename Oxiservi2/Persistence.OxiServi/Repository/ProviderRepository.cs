using Dapper;
using Domain.OxiServi.AggregatesModel.ProviderAggregate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Persistence.OxiServi.Repository
{
    public class ProviderRepository : IProviderRepository
    {
        private string _connectionString = string.Empty;
        public ProviderRepository(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<int> Create(Provider provider,XElement xElement)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@nombre", provider.Nombre, DbType.String, ParameterDirection.Input);
                parameter.Add("@numDocumento", provider.numDocumento, DbType.String, ParameterDirection.Input);
                parameter.Add("@tipDocumento", provider.tipDocumento, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@telefono", provider.telefono, DbType.String, ParameterDirection.Input);
                parameter.Add("@referente", provider.referente, DbType.String, ParameterDirection.Input);
                parameter.Add("@XMLidDetalleTipo", xElement.ToString(), DbType.Xml, ParameterDirection.Input);
                parameter.Add("@ResultId", DbType.Int32, direction: ParameterDirection.Output);
                var result = await cn.ExecuteScalarAsync<long>("[SP_Create_Proveedor]", parameter, commandType: CommandType.StoredProcedure);
                var proveedorId = parameter.Get<int>("@ResultId");
                return proveedorId;
            }
        }

        public async Task<int> Update(Provider provider, XElement xElement)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@idProveedor", provider.idProveedor, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@nombre", provider.Nombre, DbType.String, ParameterDirection.Input);
                parameter.Add("@telefono", provider.telefono, DbType.String, ParameterDirection.Input);
                parameter.Add("@referente", provider.referente, DbType.String, ParameterDirection.Input);
                parameter.Add("@numDocumento", provider.numDocumento, DbType.String, ParameterDirection.Input);
                parameter.Add("@XMLProveedorDetalle", xElement.ToString(), DbType.Xml, ParameterDirection.Input);
                parameter.Add("@ResultId", DbType.Int32, direction: ParameterDirection.Output);
                var result = await cn.ExecuteScalarAsync<long>("[SP_UPDATE_PROVEEDOR]", parameter, commandType: CommandType.StoredProcedure);
                var proveedorId = parameter.Get<int>("@ResultId");
                return proveedorId;
            }
        }
    }
}
