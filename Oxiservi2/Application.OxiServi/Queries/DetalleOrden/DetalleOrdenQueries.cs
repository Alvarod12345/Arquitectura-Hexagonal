using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OxiServi.Queries.DetalleOrden
{
    public class DetalleOrdenQueries : IDetalleOrdenQueries
    {
        public string _connectString = string.Empty;
        public DetalleOrdenQueries(string connectString)
        {
            _connectString = connectString;
        }
        public async Task<IEnumerable<DetalleOrdenViewModel>> GetAllPagination(FilterDetalleOrdenViewModel filter)
        {
            using (var connection = new SqlConnection(_connectString))
            {
                connection.Open();
                var parameter = new DynamicParameters();
                parameter.Add("@IdOrden", filter.IdOrden, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameter.Add("@fechaEntrega", filter.fechaEntrega, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameter.Add("@Page", filter.page, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameter.Add("@Rows", filter.rows, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                return await connection.QueryAsync<DetalleOrdenViewModel>(@"SP_GET_DETALLE_ORDEN_BY_ORDEN", parameter, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<OrdenMobileViewModel> GetDetalleOrdenByIdOrdenMobile(int idOrden)
        {
            using (var connection = new SqlConnection(_connectString))
            {
                connection.Open();
                var parameter = new DynamicParameters();
                parameter.Add("@IdOrden", idOrden, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                var model = await connection.QueryAsync<DetalleOrdenMobileModel>(@"SP_GET_DETALLE_ORDEN_BY_ID", parameter, commandType: CommandType.StoredProcedure);
                var orden = model.AsList<DetalleOrdenMobileModel>().GroupBy(test => test.IdOrden)
                                     .Select(grp => grp.First())
                                     .ToList();
                var detalleOrden = (from o in orden
                                    select new OrdenMobileViewModel
                                    {
                                        IdOrden = o.IdOrden,
                                        Latitud = o.Latitud,
                                        Longitud = o.Longitud,
                                        IdEstadoOrden=o.IdEstadoOrden,
                                        NombreEstadoOrden=o.NombreEstadoOrden,
                                        
                                        
                                        detalleOrden = (
                                                         from @do in model
                                                         where @do.IdOrden == o.IdOrden
                                                         select new DetalleOrdenModelMobile
                                                         {
                                                             Comentario = @do.Comentario,
                                                             Costo = @do.Costo,
                                                             Descuento = @do.Descuento,
                                                             fechaCaducidad = @do.fechaCaducidad,
                                                             IdDetalleOrden = @do.IdDetalleOrden,
                                                             IdEstadoDetalleOrden = @do.IdEstadoDetalleOrden,
                                                             EstadoOrden = @do.EstadoOrden,
                                                            NombreCliente = @do.NombreCliente,
                                                            NombreEmpresa = @do.NombreEmpresa,
                                                            NombreProducto = @do.NombreProducto
                                                        }

                                                      )
                                   }).FirstOrDefault();
                return detalleOrden;
            }
        }
    }
}
