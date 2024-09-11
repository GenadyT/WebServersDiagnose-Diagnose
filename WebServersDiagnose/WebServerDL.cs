using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL = SqlDataLayer;

namespace WebServersDiagnose
{
    public class WebServerDL
    {
        public const string SERVERS_TABLE = "tblWebServers";        
        private string connectionString;

        public WebServerDL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        internal static List<WebServer> CreateList(DataRowCollection dataRows)
        {
            List<WebServer> webServers = new List<WebServer>();

            foreach (DataRow dataRow in dataRows)
            {
                webServers.Add(new WebServer(dataRow));
            }

            return webServers;
        }

        internal async Task<List<WebServer>> ReadList()
        {
            SDL.SqlDataLayer dl = new SDL.SqlDataLayer(connectionString);
            DataTable dt = await dl.SelectDataTable($"SELECT * FROM {SERVERS_TABLE}");

            return CreateList(dt.Rows);
        }
    }
}
