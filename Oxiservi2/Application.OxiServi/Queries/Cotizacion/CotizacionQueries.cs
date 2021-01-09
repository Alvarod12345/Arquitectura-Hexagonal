using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Application.OxiServi.Queries.Cotizacion
{
    public class CotizacionQueries : ICotizacionQueries
    {
        public string _connection;
        public CotizacionQueries(string connection)
        {
            _connection = connection;
        }
        public async Task<PaginaCotizacionPaginado> GetAllCotizacionPaginado(CotizacionPaginationFilter filter)
        {
            using (var connection = new SqlConnection(_connection))
            {
                connection.Open();
                var parameter = new DynamicParameters();
                parameter.Add("@Estado", filter.estado, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameter.Add("@Page", filter.page, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameter.Add("@Rows", filter.rows, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameter.Add("@Total", System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);
                var model = await connection.QueryAsync<CotizacionPaginado>(@"SP_GET_COTIZACION", parameter, commandType: CommandType.StoredProcedure);
                var cotizacionAux = model.AsList<CotizacionPaginado>().GroupBy(test => test.IdCotizacion)
                                                                    .Select(grp => grp.First())
                                                                    .ToList();
                var listCotizacion = (from c in cotizacionAux
                                      select new Cotizacion
                                      {
                                          IdCotizacion = c.IdCotizacion,
                                          IdCliente = c.IdCliente,
                                          NombreCliente = c.NombreCliente,
                                          RazonSocial = c.RazonSocial,
                                          TipoDocumento = c.TipoDocumento,
                                          numDocumento = c.numDocumento,
                                          Monto = c.Monto,
                                          idDireccion = c.idDireccion,
                                          Direccion = c.Direccion,
                                          listProductos = (from p in model
                                                           where p.IdCotizacion == c.IdCotizacion
                                                           select new ProductoCotizacion
                                                           {
                                                               idProducto = p.idProducto,
                                                               Serie = p.Serie,
                                                               Proveedor = p.Proveedor,
                                                               idProveedor = p.idProveedor,
                                                               detalleTipo = p.detalleTipo,
                                                               idDetalleTipo = p.idDetalleTipo,
                                                               TipoProducto = p.TipoProducto,
                                                               idTipoProducto = p.idTipoProducto,
                                                               Costo = p.Costo,
                                                               Descripcion = p.Descripcion,
                                                               Capacidad = p.Capacidad,
                                                               EstadoProducto = p.EstadoProducto,
                                                               fechaCaducidad = p.fechaCaducidad,
                                                               fechaFabricacion = p.fechaFabricacion,
                                                               idEstadoProducto = p.idEstadoProducto,
                                                               isActive = p.isActive,
                                                               implemento = (from i in cotizacionAux
                                                                              select new ImplementoCotizacion
                                                                              {
                                                                                  implementoId= i.ImplementoId,
                                                                                  descripcion = i.descripcionImp,
                                                                                  costo = i.precioImp
                                                                              }
                                                                              ).FirstOrDefault()
                                                           }).ToList(),
                                      }).ToList();
                var result = new PaginaCotizacionPaginado();
                result.cotizaciones = listCotizacion;
                result.Total = parameter.Get<int>("@Total");
                return result;
            }
        }
        public async Task<Cotizacion> GetCotizacionById(int id)
        {
            using (var connection = new SqlConnection(_connection))
            {
                connection.Open();
                var parameter = new DynamicParameters();
                parameter.Add("@idCotizacion", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                var model = await connection.QueryAsync<CotizacionViewModel>(@"SP_GET_COTIZACION_BY_ID", parameter, commandType: CommandType.StoredProcedure);
                var listCotizacion = model.GroupBy(c => c.IdCotizacion)
                                                                .Select(group => group.First())
                                                                .ToList();
                var cotizacion = (from c in listCotizacion
                                  select new Cotizacion
                                  {
                                      IdCotizacion = c.IdCotizacion,
                                      IdCliente = c.IdCliente,
                                      NombreCliente = c.NombreCliente,
                                      RazonSocial = c.RazonSocial,
                                      correoElectronico = c.correoElectronico,
                                      correoElectronicoEmpresa = c.correoElectronicoEmpresa,
                                      TipoDocumento = c.TipoDocumento,
                                      numDocumento = c.numDocumento,
                                      Monto = c.Monto,
                                      Direccion = c.Direccion,
                                      listProductos = (from p in model
                                                       where p.IdCotizacion == c.IdCotizacion
                                                       select new ProductoCotizacion
                                                       {
                                                           Serie = p.serie,
                                                           Descripcion = p.descripcionProd,
                                                           Capacidad = p.Capacidad,
                                                           Costo = p.precioProd
                                                       }).ToList(),
                                  }).FirstOrDefault();
                return cotizacion;

            }
        }
    }
}
