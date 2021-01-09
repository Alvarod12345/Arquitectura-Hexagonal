using Dapper;
using Domain.OxiServi.AggregatesModel.MovimientoAggregate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.OxiServi.Repository
{
    public class MovimientoRepository : IMovimientoRepository
    {
        private string _connectionString = string.Empty;
        public MovimientoRepository(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }
        public async Task<int> Create(Movimiento mov)
        {
            using(var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameter = new DynamicParameters();
               
                parameter.Add("@idtipomovimiento", mov.idTipoMovimiento, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@fechasalida", mov.fechaSalida, DbType.DateTime, ParameterDirection.Input);
                parameter.Add("@fechaentrada", mov.fechaEntrada, DbType.DateTime, ParameterDirection.Input);
                parameter.Add("@resultIdMovimiento", DbType.Int32, direction: ParameterDirection.Output);
                var result = await cn.ExecuteScalarAsync<long>("SP_Create_Movimiento", parameter, commandType: CommandType.StoredProcedure);
                var MoveId = parameter.Get<int>("@resultIdMovimiento");

                return MoveId;
            }
        }
    }
}
