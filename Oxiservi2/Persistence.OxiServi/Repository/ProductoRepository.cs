using Dapper;
using Domain.OxiServi.AggregatesModel.ProductoAggregate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.OxiServi.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private string _connectionString = string.Empty;
        public ProductoRepository(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }
        public async Task<int> Create(Producto prod)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@Serie", prod.Serie, DbType.String,ParameterDirection.Input);
                parameter.Add("@Descripcion", prod.Descripcion, DbType.String, ParameterDirection.Input);
                parameter.Add("@Capacidad", prod.Capacidad, DbType.Double, ParameterDirection.Input);
                parameter.Add("@FechaFabricacion", prod.fechaFabricacion, DbType.DateTime, ParameterDirection.Input);
                parameter.Add("@FechaCaducidad", prod.fechaCaducidad, DbType.DateTime, ParameterDirection.Input);
                parameter.Add("@Costo", prod.Costo, DbType.Double, ParameterDirection.Input);
                parameter.Add("@IdProveedor", prod.idProveedor, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@IdDetalleTipo", prod.IdDetalleTipoDescripcion, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@Result", DbType.Int32 , direction: ParameterDirection.Output);
                var result = await cn.ExecuteScalarAsync<long>("SP_Create_Producto", parameter, commandType: CommandType.StoredProcedure);
                var userId = parameter.Get<int>("@Result");
                return userId;
            }
        }
        public async Task<int> Update(Producto prod)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@IdProducto", prod.idProducto, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@Serie", prod.Serie, DbType.String, ParameterDirection.Input);
                parameter.Add("@IdProveedor", prod.idProveedor, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@IdDetalleTipo", prod.IdDetalleTipoDescripcion, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@Descripcion", prod.Descripcion, DbType.String, ParameterDirection.Input);
                parameter.Add("@Capacidad", prod.Capacidad, DbType.Double, ParameterDirection.Input);
                parameter.Add("@fechaFabricacion", prod.fechaFabricacion, DbType.DateTime, ParameterDirection.Input);
                parameter.Add("@fechaCaducidad", prod.fechaCaducidad, DbType.DateTime, ParameterDirection.Input);
                parameter.Add("@Costo", prod.Costo, DbType.Double, ParameterDirection.Input);
                parameter.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result = await cn.ExecuteScalarAsync<long>("SP_Update_Producto", parameter, commandType: CommandType.StoredProcedure);
                var resultId = parameter.Get<int>("@Result");
                return resultId;
            }
        }

        public async Task<bool> ValidateSerie(string serie)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@Serie", serie, DbType.String, ParameterDirection.Input);
                parameter.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                await cn.ExecuteScalarAsync<long>("SP_Validate_Serie", parameter, commandType: CommandType.StoredProcedure);
                var result = parameter.Get<int>("@Result");
                if (result == 0)
                    return false;
                else
                    return true;
            }
        }

        public async Task<bool> DesactivarProducto(Producto prod)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
                parameter.Add("@idProducto", prod.idProducto, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@resultId", DbType.Boolean, direction: ParameterDirection.Output);
                await cn.ExecuteScalarAsync<long>("SP_DESACTIVAR_PRODUCTO", parameter, commandType: CommandType.StoredProcedure);
                var result = parameter.Get<int>("@resultId");
                if (result == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }       
    }
}
