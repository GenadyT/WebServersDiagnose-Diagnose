using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP
{
    public interface IObserver
    {
        //internal void Update(List<WebServer> observeeData);
        public void Update(DataRowCollection notifyData);

        public void UnRegister();
    }
}
