using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace WebServersManager.DP
{
    public abstract class Observee
    {
        protected List<IObserver> observers;

        public Observee()
        {
            this.observers = new List<IObserver>();
        }

        public abstract void RegisterObserver(IObserver observer);
        public abstract void RemoveObserver(IObserver observer);
        //internal abstract void NotifyObservers(List<WebServer> webServers);
        public abstract void NotifyObservers(DataRowCollection notifyData);
    }
}
