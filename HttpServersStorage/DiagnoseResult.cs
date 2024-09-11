using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpServersStorage
{
    public class DiagnoseResult
    {
		private int httpResponseCode;
		public int HttpResponseCode
        {
			get { return httpResponseCode; }
			//set { httpResponseCode = value; }
		}

		private double httpResponseLatency;
		public double HttpResponseLatency
        {
			get { return httpResponseLatency; }
			//set { httpResponseLatency = value; }
		}

		public DiagnoseResult(int httpResponseCode, double httpResponseLatency) 
		{ 
			this.httpResponseCode = httpResponseCode;
			this.httpResponseLatency = httpResponseLatency;
		}
    }
}
