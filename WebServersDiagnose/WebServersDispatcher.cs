using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using WebServersManager.DP;

namespace WebServersDiagnose
{
    enum EteratorType
    {
        BaseIterator = 1,
        UnbaseIterator = 2,
    }

    public class WebServersDispatcher : IObserver, IAggregate<WebServer>, IDisposable
    {
        private WebServerDL webServerDL;
        private List<WebServer> webServers;        
        private ServersDiagnoseLoop serversManagerLoop;
        private int iteratorType = (int)EteratorType.BaseIterator;

        public WebServersDispatcher(DataTableObservee serversStockObservee, string connectionString)
        {   
            this.webServerDL = new WebServerDL(connectionString);
            this.webServers = new List<WebServer>();

            serversStockObservee.RegisterObserver(this);
            
            int iteratorType = (int)EteratorType.BaseIterator;
            this.serversManagerLoop = new ServersDiagnoseLoop(CreateIterator(iteratorType), connectionString);              
        }
        
        public void Update(DataRowCollection notifyData)
        {
            refreshIterator(notifyData);
        }

        private void refreshIterator(DataRowCollection notifyData)
        {
            webServers = WebServerDL.CreateList(notifyData);
            serversManagerLoop.SetIterator(CreateIterator(iteratorType));
        }

        public void UnRegister()
        {
            webServers = null;
            Dispose();
        }

        public async void Start(double checkInterval)
        {   
            webServers = await webServerDL.ReadList();

            int iteratorType = (int)EteratorType.BaseIterator;
            serversManagerLoop.SetIterator(CreateIterator(iteratorType));
            
            serversManagerLoop.Start(checkInterval);
        }

        public void Stop()
        {            
            serversManagerLoop.Stop();
        }

        public SimpleIterator<WebServer> CreateIterator(int iteratorType)
        {
            return new WebServersIterator(webServers);
        }

        public void Dispose() {
            foreach (WebServer server in webServers)
            {
                //server.Dispose();
            }
        }

        ~WebServersDispatcher()
        {
            Dispose();
        }
    }
}
