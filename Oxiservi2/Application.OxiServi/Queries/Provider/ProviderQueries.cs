using Application.OxiServi.Queries.Base;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.OxiServi.Queries.Provider
{
    public class ProviderQueries : IProviderQueries
    {
        private string _connectionString = string.Empty;
        public ProviderQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }
        public async Task<IEnumerable<ProviderViewModel>> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                DynamicParameters parameter = new DynamicParameters();
                return await connection.QueryAsync<ProviderViewModel>(@"SP_GET_PROVEEDORES", parameter, commandType:CommandType.StoredProcedure);
            }
        }
        
        //public async Task<ProviderViewModel> GetProviderByNames(ListarProviderByNamesParameter namepr)
        //{
        //    using (var connection = new SqlConnection(_connectionString))
        //    {
        //        connection.Open();
        //        var parameter = new DynamicParameters();
        //        parameter.Add("@Nombre", namepr.nombre, System.Data.DbType.String, System.Data.ParameterDirection.Input);
        //        return await connection.QueryFirstAsync<ProviderViewModel>(@"SP_GET_PROVEEDORES_BY_NOMBRE", parameter, commandType: System.Data.CommandType.StoredProcedure);
        //    }
        //}

        public async Task<ProviderViewModelPaginado> GetAllPaginado(FilterProvider listarParameter)
        {
            var model = new ProviderViewModelPaginado();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Page", listarParameter.page, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameter.Add("@Rows", listarParameter.rows, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameter.Add("@idproveedor", listarParameter.idProveedor, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameter.Add("@nombre", listarParameter.nombre, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameter.Add("@numdocumento", listarParameter.numDocumento, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameter.Add("@Total", DbType.Int32, direction: System.Data.ParameterDirection.Output);
                var model1 =  await connection.QueryAsync<ProviderViewModel>(@"SP_GET_PROVEEDOR_PAGINADO", parameter, commandType: System.Data.CommandType.StoredProcedure);
                model.total = parameter.Get<int>("@Total");
                var proveedoresVar = model1.AsList<ProviderViewModel>().GroupBy(test => test.idProveedor)
                                                                    .Select(grp => grp.First())
                                                                    .ToList();
                // var tiposProducto = proveedoresVar.AsList<ProviderViewModel>().GroupBy(test => test.idTipoProducto).Select(grp => grp.First()).ToList();
                // var detalleTipos = tiposProducto.AsList<ProviderViewModel>().GroupBy(test => test.idTipoProducto).Select(grp => grp.First()).ToList();
                var listaProveedores = (from o in proveedoresVar
                                        select new ListarProviderViewModel
                                        {
                                            idProveedor = o.idProveedor,
                                            nombre = o.nombre,
                                            numDocumento = o.numDocumento,
                                            tipoDocumento = o.tipoDocumento,
                                            telefono = o.telefono,
                                            referente = o.referente,
                                            tipoProducto = (
                                                        from @do in model1
                                                        where @do.idProveedor == o.idProveedor
                                                        select new TipoProducto
                                                        {
                                                            idTipoProducto = @do.idTipoProducto,
                                                            Nombre_TipoProducto = @do.Nombre_TipoProducto,                                                            
                                                            tipoDetalle = (from @do1 in model1
                                                                           where @do1.idProveedor == @do.idProveedor && @do1.idTipoProducto == @do.idDetalleTipo
                                                                           select new TipoDetalle {
                                                                               idDetalleTipo = @do1.idDetalleTipo,
                                                                               descripcion = @do1.descripcion,
                                                                               isRecarga = @do1.isRecarga,
                                                                               isVendedor = @do1.isVendedor,
                                                                           }).ToList()
                                                        }
                                                           ).GroupBy(grp => grp.idTipoProducto)
                                                           .Select(grp => grp.First())
                                                           .ToList()
                                        }).ToList();
                model.lista = listaProveedores;
                return model;
            }
        }

        public async Task<IEnumerable<ProviderViewModel>> GetAutocomplete(string query)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return await connection.QueryAsync<ProviderViewModel>(@"SP_GET_AUTOCOMPLETE_PROOVERDOR", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<ProviderViewModel> GetProviderById(ListarProviderByIdParameter id_paramter)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var parameter = new DynamicParameters();
                parameter.Add("@idProvedor", id_paramter.idProveedor, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                return await connection.QueryFirstAsync<ProviderViewModel>(@"SP_GET_PROVEEDOR_BY_ID", parameter, commandType: System.Data.CommandType.StoredProcedure);
            }
            

        }
        public async Task<IEnumerable<ProviderViewModel>> GetProviderByDetalleTipoProducto(XElement xElement)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var parameter = new DynamicParameters();
                parameter.Add("@XMLDetalleTipo", xElement.ToString(), System.Data.DbType.Xml, System.Data.ParameterDirection.Input);
                return await connection.QueryAsync<ProviderViewModel>(@"SP_GET_PROVEEDOR_BY_DETALLE_TIPOPRODUCTO", parameter, commandType: System.Data.CommandType.StoredProcedure);
            }


        }
    }
}
