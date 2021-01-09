using CrossCutting.Utility.OxiServi.Extensions;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.OxiServi.Job
{
    public class OrdenJobRepository
    {
        public async Task UpdateEstado(string connection)
        {
            var date = DateExtensions.GetDate();
            using (var cn = new SqlConnection(connection))
            {
                cn.Open();
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@TodayDate", date, DbType.DateTime, ParameterDirection.Input);
                var result = await cn.ExecuteAsync("[UPDATE_ESTADO_EN_ESPERA_JOB]", parameter, null, null, CommandType.StoredProcedure);
            }
        }
    }
}
