using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServersManager.Utilities;
using WebServersManager.DP;
using HttpServersStorage;

namespace WebServersDiagnose
{
    public class ServersDiagnoseLoop : IDisposable
    {
        private SimpleTimer timer;
        private ServerDiagnostic serverDiagnostic;
        private DiagnoseHistorySaver diagnoseHistorySaver;

        private SimpleIterator<WebServer> serversIterator;
        private List<string> httpURLs;

        public ServersDiagnoseLoop(SimpleIterator<WebServer> serversIterator, string connectionString)
        {   
            this.serverDiagnostic = new ServerDiagnostic();
            this.diagnoseHistorySaver = new DiagnoseHistorySaver(connectionString);

            this.serversIterator = serversIterator;
            httpURLs = new List<string>();
            
            this.timer = new SimpleTimer(handleTimer);
        }

        public void SetIterator(SimpleIterator<WebServer> newServersIterator)
        {
            if ((newServersIterator == null) || (serversIterator == null) ) return;

            this.serversIterator = newServersIterator;

            serversIterator.Reset();
            while (serversIterator.MoveNext())
            {
                var serverIdForCheck = serversIterator.Current.ID;
                if (!newServersIterator.Exists(serverIdForCheck))
                {
                    var httpURL = serversIterator.Current.HttpURL;
                    this.httpURLs.Remove(httpURL);
                }
            }

            newServersIterator.Reset();
            while (newServersIterator.MoveNext())
            {
                var serverIdForCheck = newServersIterator.Current.ID;
                if (!serversIterator.Exists(serverIdForCheck))
                {
                    var httpURL = serversIterator.Current.HttpURL;
                    this.httpURLs.Add(httpURL);
                }
            }

            this.serversIterator = newServersIterator;
        }

        private void handleTimer(string timerInfo)
        {
            //Logger.Write(timerInfo);

            if (serversIterator != null)
            {
                serversIterator.Reset();

                DateTime monitorTime = DateTime.Now;

                while (serversIterator.MoveNext())
                {
                    WebServer server = serversIterator.Current;
                    Task<DiagnoseResult> diagnoseResult = serverDiagnostic.Diagnose(server.HttpURL);
                    diagnoseHistorySaver.Save(server.ID, monitorTime, diagnoseResult);
                }
            }
        }

        public void Start(double checkInterval)
        {
            timer.Start(checkInterval);
        }

        public void Stop()
        {
            timer.Stop();
        }

        public void Dispose()
        {
            timer.Dispose();
        }

        ~ServersDiagnoseLoop()
        {
            Dispose();
        }
    }
}
