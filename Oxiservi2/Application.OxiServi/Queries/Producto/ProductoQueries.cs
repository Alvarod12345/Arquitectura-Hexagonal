using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace Application.OxiServi.Queries.Producto
{
    public class ProductoQueries : IProductoQueries
    {
        private string _connectionString = string.Empty;
        public ProductoQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }
        public async Task<IEnumerable<ProductoViewModel>> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return await connection.QueryAsync<ProductoViewModel>(@"SP_GET_PRODUCTO", commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<ProductoViewModel> GetAllById(ListarProductoByIdParametro pr)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var parameter = new DynamicParameters();
                parameter.Add("@idProducto", pr.idProducto, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                return await connection.QueryFirstAsync<ProductoViewModel>(@"SP_GET_PRODUCTO_BY_ID", parameter ,commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<ListarTipoProductoViewModel>> GetTipoProducto()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return await connection.QueryAsync<ListarTipoProductoViewModel>(@"SP_GET_TIPO_PRODUCTO", commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<ListarProductoViewModel> GetAllPaginado(ListarFiltroProductoViewModel filter)
        {
            var model = new ListarProductoViewModel();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var parameter = new DynamicParameters();
                parameter.Add("@Page",filter.page , System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameter.Add("@Rows", filter.rows, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameter.Add("@EstadoProducto", filter.EstadoProducto, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameter.Add("@IdTipoProducto", filter.idTipoProducto, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameter.Add("@IdDetalleTipoProducto", filter.idDetalleTipoProducto, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameter.Add("@Serie", filter.Serie, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameter.Add("@Total",  System.Data.DbType.Int32, direction : System.Data.ParameterDirection.Output);

                model.rows = await connection.QueryAsync<ProductoViewModel>(@"SP_GET_PRODUCTO_PAGINADO", parameter, commandType: CommandType.StoredProcedure);
                model.Total = parameter.Get<int>("@Total");
                return model;
            }
        }

        public async Task<IEnumerable<ProductoViewModel>> GetAutocomplete(string query)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var parameter = new DynamicParameters();
                parameter.Add("@query", query, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                return await connection.QueryAsync<ProductoViewModel>(@"SP_GET_AUTOCOMPLETE_PRODUCTO", parameter, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<ListarProductoRecarga>> GetProductoRecarga(string query)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var parameter = new DynamicParameters();
                parameter.Add("@query", query, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                return await connection.QueryAsync<ListarProductoRecarga>(@"SP_GET_PRODUCTO_RECARGA", parameter, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
