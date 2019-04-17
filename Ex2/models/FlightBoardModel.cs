using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex2.models
{
    class FlightBoardModel 
    {
        private Commands client;
        private Info server;
        public double longitude;
        public double latitude;
        private bool notifyChanged;
        public FlightBoardModel()
        {
            client = Commands.commandInstance;
            server = Info.infoInstance;
            
        }
        public void connect()
        {
            Thread threadServer = new Thread(new ThreadStart(() => 
            {
                server.connect();
            }));            threadServer.Start();
            while (!server.isConnection())
            {
            }
            Thread threadClient = new Thread(new ThreadStart(() =>
            {
                client.connect();
            }));            threadClient.Start();
            Thread readValues = new Thread(new ThreadStart(() =>
            {
                while (server.isConnection())
                {
                    NotifyP = false;
                
                    string values = server.flightValuesP;
                    if (values != "")
                    {
                        double prevLon = Lon;
                        double prevLat = Lat;
                        string[] splitValues = values.Split(',');
                        Lon = Convert.ToDouble(splitValues[0]);
                        Lat = Convert.ToDouble(splitValues[1]);
       
                        if ((prevLat != Lat) || (prevLon != Lon))
                        {
                            NotifyP = true;
                        }
                    }
                }
            }));            readValues.Start();
        }
        public double Lon
        {
            get { return longitude; }
            set { this.longitude = value;
            }
        }
        public Info serverP
        {
            get { return server; }
        }
        public Commands clientP
        {
            get { return client; }
        }
        public double Lat
        {
            get { return latitude; }
            set { this.latitude = value; }
        }

        public bool NotifyP
        {
            get { return notifyChanged; }
            set { notifyChanged = value; }
        }
    } 
}
