using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServersDiagnose
{
    public class WebServersManager
    {
        private DataTableObservee serversStockObservee;
        private WebServersDispatcher webServersDispatcher;

        public WebServersManager(string connectionString)
        {
            serversStockObservee = new DataTableObservee(WebServerDL.SERVERS_TABLE, connectionString);
            webServersDispatcher = new WebServersDispatcher(serversStockObservee, connectionString);
        }

        public void Start(double checkInterval)
        {
            webServersDispatcher.Start(checkInterval);
            serversStockObservee.Start();
        }

        public void Stop()
        {
            serversStockObservee.Stop();
        }
    }
}
