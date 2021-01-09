using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using System.Threading.Tasks;
using System.Data;
using System.Linq;

namespace Application.OxiServi.Queries.Cliente
{
    public class ClienteQueries : IClienteQueries
    {
        public string conexion;
        public ClienteQueries(string conection) {
            this.conexion = conection;
        }

        public async Task<ClientePaginationViewModel> GetAllPagination(FilterClienteViewModel filter)
        {
            using (var connection = new SqlConnection(conexion))
            {
                var model = new ClientePaginationViewModel();
                connection.Open();
                var parameter = new DynamicParameters();
                parameter.Add("@Page", filter.page, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameter.Add("@Rows", filter.rows, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

                parameter.Add("@NombreCliente", filter.NombreCliente, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameter.Add("@RazonSocial", filter.RazonSocial, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameter.Add("@NumeroDocumento", filter.NumeroDocumento, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameter.Add("@TipoDocumento", filter.TipoDocumento, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

                parameter.Add("@Total", System.Data.DbType.Int32, direction : System.Data.ParameterDirection.Output);
                var clientes = await connection.QueryAsync<ClienteBasePaginationViewModel>(@"[SP_GET_CLIENTE_PAGINADO]", parameter, commandType: CommandType.StoredProcedure);
                model.rows =   (from p in clientes
                               select new ClientePaginationModel
                               {
                                       idCliente = p.idCliente,
                                       numDocumento = p.numDocumento,
                                       tipoDocumento = p.tipoDocumento,
                                       tipoDocumentoStr = p.tipoDocumentoStr,
                                       empresa = new ClienteEmpresaModel {
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
                               }).ToList();
                model.Total = parameter.Get<int>("@Total");
                return model;
            }
        }

        public async Task<IEnumerable<ClientePaginationModel>> GetClienteCotizacion(FilterClienteCotizacionViewModel filter)
        {
            using (var conection = new SqlConnection(conexion))
            {
                conection.Open();
                var parameter = new DynamicParameters();
                parameter.Add("@NombreCliente", filter.NombreCliente, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameter.Add("@RazonSocial", filter.RazonSocial, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameter.Add("@NumeroDocumento", filter.NumeroDocumento, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameter.Add("@TipoDocumento", filter.TipoDocumento, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                var clientes = await conection.QueryAsync<ClienteBasePaginationViewModel>(@"[SP_GET_CLIENTE_COTIZACION]", parameter, commandType: CommandType.StoredProcedure);
                var list = (from p in clientes
                              select new ClientePaginationModel
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
                                      telefono = p.telefono,
                                      RUC = p.RUC
                                  }
                              }).ToList();
                return list;
            }
        }
    }
}
