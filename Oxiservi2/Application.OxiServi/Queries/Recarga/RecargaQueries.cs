using Application.OxiServi.Queries.Producto;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OxiServi.Queries.Recarga
{
    public class RecargaQueries : IRecargaQueries
    {
        private string _connectionString = string.Empty;
        public RecargaQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<IEnumerable<RecargaViewModel>> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return await connection.QueryAsync<RecargaViewModel>(@"SP_GET_RECARGA_PRODUCTO", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<RecargaViewModel>> GetNoAtendidas()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return await connection.QueryAsync<RecargaViewModel>(@"SP_GET_RECARGA_NO_ATENDIDA", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<RecargaByIdViewModel> GetRecargaById(int idRecarga)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var parameter = new DynamicParameters();
                parameter.Add("@idRecarga", idRecarga, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                var result = await connection.QueryAsync<ProductoRecargaBaseModel>(@"SP_GET_RECARGA_BY_ID", parameter, commandType: CommandType.StoredProcedure);
                var recarga = result.GroupBy(test => test.idRecarga)
                                  .Select(grp => grp.First())
                                  .ToList().FirstOrDefault();
                return new RecargaByIdViewModel
                {
                    idRecarga = idRecarga,
                    productos = (
                                   from re in result
                                   select new ProductoRecargaViewModel
                                   {
                                       Serie = re.Serie,
                                       DetalleTipoProducto = re.DetalleTipoProducto,
                                       DetalleTipoProductoId = re.DetalleTipoProductoId,
                                       idProducto = re.idProducto,
                                       Producto = re.Producto,
                                       TipoProducto = re.TipoProducto,
                                       TipoProductoId = re.TipoProductoId,
                                       Estado = re.EstadoProducto,
                                       EstadoProductoId = re.EstadoProductoId
                                   }
                                ).ToList()
                };
            }
        }
    }
}
