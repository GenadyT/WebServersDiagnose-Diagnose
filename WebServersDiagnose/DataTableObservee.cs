using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using WebServersManager.DP;
using SqlDataLayer;

namespace WebServersDiagnose
{
    public class DataTableObservee : Observee
    {
        private SqlDependencyManager sqlDependencyManager;

        public DataTableObservee(string tableName, string connectionString)
        {
            sqlDependencyManager = new SqlDependencyManager(tableName, connectionString, stockChangedHandler);
        }

        public void stockChangedHandler(DataRowCollection dataRows)
        {
            /*List<WebServer> webServers = new List<WebServer>();
            foreach (DataRow row in dataRows)
            {
                webServers.Add(new WebServer(row));
            }

            NotifyObservers(webServers);*/

            NotifyObservers(dataRows);
        }

        //-----------------------------------------------
        public override void RegisterObserver(IObserver observer)
        {
            base.observers.Add(observer);
        }

        public override void RemoveObserver(IObserver observer)
        {
            base.observers.Remove(observer);
        }

        //internal override void NotifyObservers(List<WebServer> webServers)
        public override void NotifyObservers(DataRowCollection notifyData)
        {
            foreach (IObserver obs in observers)
            {
                //obs.Update(webServers);
                obs.Update(notifyData);
            }
        }
        //-----------------------------------------------

        public void Start()
        {
            sqlDependencyManager.Start();
        }

        public void Stop()
        {
            sqlDependencyManager.Stop();
        }
    }
}
