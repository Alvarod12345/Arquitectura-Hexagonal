using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Application.OxiServi.Queries.Movimiento
{
    public class MovimientoQueries : IMovimientoQueries
    {
        private string _connectionString = string.Empty;
        public MovimientoQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }
        public async Task<IEnumerable<MovimientoViewModel>> GetAll()
        {
            IEnumerable<MovimientoViewModel> result;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                DynamicParameters parameter = new DynamicParameters();
                result = await connection.QueryAsync<MovimientoViewModel>(@"SP_GET_MOVIMIENTO",parameter ,commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<MovimientoPaginado> GetAllPaginado(ListarMovimientoViewModel listarParameter)
        {
            var model = new MovimientoPaginado();
            using (var connection = new SqlConnection(_connectionString))   
            {
                connection.Open();
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Page", listarParameter.page, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameter.Add("@Rows", listarParameter.rows, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameter.Add("@Total", System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);
                model.movimiento = await connection.QueryAsync<MovimientoPaginadoViewModel>(@"SP_GET_MOVIMIENTO_PAGINADO", parameter, commandType: System.Data.CommandType.StoredProcedure);
                model.Total = parameter.Get<int>("@Total");
                return model;
            }
        }
        public async Task<MovimientoDetalle> GetMovimientoDetalle(ListarMovimientoViewModel listarParameter)
        {
            var model = new MovimientoDetalle();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Page", listarParameter.page, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameter.Add("@Rows", listarParameter.rows, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameter.Add("@Total", System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);
                model.movimentoD = await connection.QueryAsync<MovimientoDetalleViewModel>(@"SP_GET_MOVIMIENTO_DETALLE", parameter, commandType: System.Data.CommandType.StoredProcedure);
                model.Total = parameter.Get<int>("@Total");
                return model;
            }
        }

    }
}
