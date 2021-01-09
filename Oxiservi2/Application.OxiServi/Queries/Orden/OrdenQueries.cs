using Application.OxiServi.Queries.Cliente;
using CrossCutting.Utility.OxiServi.Extensions;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Application.OxiServi.Queries.Orden
{
    public class OrdenQueries : IOrdenQueries
    {
        public string _connectionString = string.Empty; 
        public OrdenQueries(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<IEnumerable<OrdenViewModel>> GetAllPagination(FilterOrdenViewModel filter)
        {
            var fecha = DateTime.ParseExact(filter.fechaEntrega, "dd/MM/yyyy", null);
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var parameter = new DynamicParameters();
                parameter.Add("@fechaEntrega", fecha, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameter.Add("@Page", filter.page, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameter.Add("@Rows", filter.rows, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                var resyult =  await connection.QueryAsync<OrdenViewModel>(@"SP_GET_ORDEN_PAGINADO", parameter, commandType: CommandType.StoredProcedure);
                return resyult;
            }
        }

        public async Task<OrdenWebPaginationViewModel> GetAllPaginationWeb(FilterOrdenWebViewModel filter)
        {
            var date = string.IsNullOrEmpty(filter.fechaEntrega) ? DateExtensions.GetMinValue() : DateTime.ParseExact(filter.fechaEntrega,"dd/MM/yyyy",null);
            var model = new OrdenWebPaginationViewModel();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var parameter = new DynamicParameters();
                parameter.Add("@Page", filter.page, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameter.Add("@Rows", filter.rows, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

                parameter.Add("@NombreCliente", filter.NombreCliente, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameter.Add("@RazonSocial", filter.RazonSocial, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameter.Add("@NumeroDocumento", filter.numDocumento, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameter.Add("@TipoDocumento", filter.idTipoDocumento, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameter.Add("@fechaEntrega", date, System.Data.DbType.String, System.Data.ParameterDirection.Input);

                parameter.Add("@IdEstadoOrden", filter.idEstadoOrden, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameter.Add("@FechaEntrega", date, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

                parameter.Add("@Total", System.Data.DbType.Int32, direction : System.Data.ParameterDirection.Output);

                var orden = await connection.QueryAsync<OrdenWebViewModelBase>(@"SP_GET_ORDEN_PAGINADO_WEB", parameter, commandType: CommandType.StoredProcedure);
                model.orden = ( from p in orden
                                          select new OrdenWebViewModel
                                          {
                                              cliente = new ClientePaginationModel
                                              {
                                                  idCliente = p.idCliente,
                                                  numDocumento = p.numDocumento,
                                                  tipoDocumento = p.tipoDocumento,
                                                  tipoDocumentoStr = p.tipoDocumentoStr,
                                                  empresa = new ClienteEmpresaModel
                                                  {
                                                      idDatosEmpresa = p.idDatosEmpresa,
                                                      nombreContacto = p.nombreContacto,
                                                      paternoContacto = p.paternoContacto,
                                                      maternoContacto = p.maternoContacto,
                                                      numDocumentoContacto = p.numDocumentoContacto,
                                                      correoElectronicoContacto = p.correoElectronicoContacto,
                                                      razonSocial = p.razonSocial,
                                                      telefonoContacto = p.telefonoContacto,
                                                      tipoDocumentoContacto = p.tipoDocumentoContacto,
                                                      tipoDocumentoContactoStr = p.tipoDocumentoContactoStr
                                                  },
                                                  persona = new ClientePersonaModel
                                                  {
                                                      idDatosCliente = p.idDatosCliente,
                                                      correoElectronico = p.correoElectronico,
                                                      materno = p.materno,
                                                      paterno = p.paterno,
                                                      nombre = p.nombre,
                                                      telefono = p.telefono
                                                  }
                                              },
                                              orden = new OrdenViewModel
                                              {
                                                  idOrden = p.idOrden,
                                                  idCliente = p.idCliente,
                                                  EstadoOrden = p.estadoOrden,
                                                  idEstadoOrden = p.idEstadoOrden,
                                                  fechaEntrega = p.fechaEntrega
                                              } 
                                          }).ToList();
                model.Total = parameter.Get<int>("@Total");
                return model;
            }
        }

        public async Task<IEnumerable<EstadoOrdenViewModel>> GetEstadoDispoible(int estado)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var parameter = new DynamicParameters();
                parameter.Add("@idEstado", estado, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                return await connection.QueryAsync<EstadoOrdenViewModel>(@"SP_GET_ESTADO_DISPONIBLE", parameter, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<FacturaOrdenViewModel> GetFacturaByOrden(int idOrden)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var parameter = new DynamicParameters();
                parameter.Add("@IdOrden", idOrden, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                var detalleOrden = await connection.QueryAsync<FacturaOrdenBaseModel>(@"SP_GET_FACTURA_BY_ORDEN", parameter, commandType: CommandType.StoredProcedure);
                var orden = detalleOrden.GroupBy(test => test.idOrden)
                                     .Select(grp => grp.First())
                                     .ToList();
                var result = (from o in orden
                              select new FacturaOrdenViewModel
                              {
                                  idOrden = o.idOrden,
                                  Direccion = o.Direccion,
                                  numDocumento = o.numDocumento,
                                  tipoDocumento = o.TipoDocumento,
                                  correoElectronico = o.correoElectronico is null ? o.correoElectronicoEmpresa: o.correoElectronico,
                                  FullName = o.ClienteName is null ? o.RazonSocial : o.ClienteName,
                                  IdTipoComprobante = o.IdTipoComprobante,
                                  TipoComprobante = o.TipoComprobante,
                                  Total = (
                                               from @do in detalleOrden
                                               where o.idOrden == @do.idOrden
                                               select @do.PUnitario
                                             ).Sum(),
                                  SubTotal = (
                                               from @do in detalleOrden
                                               where o.idOrden == @do.idOrden
                                               select @do.PUnitario
                                             ).Sum(),
                                  detalleOrden = (
                                                    from @do in detalleOrden
                                                    where o.idOrden == @do.idOrden
                                                    select new FacturaDetalleOrdenViewModel
                                                    { 
                                                        DetalleTipoProducto = @do.DetalleTipo,
                                                        Descripcion = @do.Descripcion,
                                                        PUnitario = @do.PUnitario,

                                                        Serie = @do.Serie,
                                                    }
                                                 ).ToList()
                              }).FirstOrDefault();
                return result;
            }
        }
    }
}
