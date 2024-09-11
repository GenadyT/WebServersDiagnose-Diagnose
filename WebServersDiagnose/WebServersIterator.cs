using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebServersManager.DP;

namespace WebServersDiagnose
{
    internal class WebServersIterator : SimpleIterator<WebServer>
    {
        private List<WebServer> webServers;

        public WebServersIterator(List<WebServer> webServers)
        {
            if (webServers == null) throw new ArgumentNullException();

            this.webServers = webServers;            
            base.index = 0;
        }

        public override WebServer Current
        {
            get { return webServers[index]; }
        }

        public override bool MoveNext()
        {
            if (index == webServers.Count - 1)
            {
                return false;
            }
            else
            {
                index++;
                return true;
            }
        }

        public override bool Exists(int serverID)
        {
            int count = webServers.Select(webServer => webServer.ID == serverID).Count();
            return count > 0;
        }
    }
}
