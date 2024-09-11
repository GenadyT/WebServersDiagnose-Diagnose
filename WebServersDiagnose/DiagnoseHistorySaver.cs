using SqlDataLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL = SqlDataLayer;
using HttpServersStorage;

namespace WebServersDiagnose
{
    internal class DiagnoseHistorySaver
    {
        private SDL.SqlDataLayer sqlDataLayer;

        internal DiagnoseHistorySaver(string connectionString)
        {
            sqlDataLayer = new SDL.SqlDataLayer(connectionString);
        }

        internal async Task Save(int serverID, DateTime monitorTime, Task<DiagnoseResult> diagnoseResult)
        {
            List<SqlParameter> lstSqlParams = composeSqlParams(
                serverID, 
                monitorTime, 
                diagnoseResult.Result.HttpResponseCode, 
                diagnoseResult.Result.HttpResponseLatency);
            await sqlDataLayer.RunScalarSP("spInsertMonitorHistory", lstSqlParams);
        }

        internal List<SqlParameter> composeSqlParams(int serverID, DateTime monitorTime, int httpResponseCode, double httpResponseLatency)
        {
            List<SqlParameter> lstSqlParams = new List<SqlParameter>();
            SqlParameter sqlParameter;

            sqlParameter = new SqlParameter("@ServerID", serverID);
            lstSqlParams.Add(sqlParameter);

            sqlParameter = new SqlParameter("@MonitorTime", monitorTime);
            lstSqlParams.Add(sqlParameter);

            sqlParameter = new SqlParameter("@HttpResponseCode", httpResponseCode);
            lstSqlParams.Add(sqlParameter);

            sqlParameter = new SqlParameter("@HttpResponseLatency", Convert.ToInt32(httpResponseLatency));
            lstSqlParams.Add(sqlParameter);

            return lstSqlParams;
        }
    }
}
