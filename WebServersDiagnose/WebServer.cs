using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServersDiagnose
{
    public class WebServer
    {
		private int id;
		public int ID
		{
			get { return id; }
			//set { myVar = value; }
		}

        private string name;
        public string Name
        {
            get { return name; }
            //set { name = value; }
        }

        private string httpURL;
        public string HttpURL
        {
            get { return httpURL; }
            //set { httpURL = value; }
        }

        private int healthID;
        public int HealthID
        {
            get { return healthID; }
            //set { healthID = value; }
        }

        public WebServer(int id, string name, string httpURL, int healthID) 
        { 
            this.id = id;
            this.name = name;
            this.httpURL = httpURL;
            this.healthID = healthID;
        }

        public WebServer(DataRow dataRow) : this(
            Convert.ToInt32(dataRow["ID"]),
            dataRow["Name"].ToString(),
            dataRow["HttpURL"].ToString(),
            Convert.ToInt32(dataRow["HealthID"])
         ) { }

        public void HealthUpdate(int healthID)
        {
            this.healthID = healthID;
        }
    }
}
